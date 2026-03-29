using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using DataAccess.Concrate.Repository;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfNoteDal : GenericRepository<Note>, INoteDal
{
    private readonly BlogContexts _context;

    public EfNoteDal(BlogContexts context) : base(context)
    {
        _context = context;
    }

    public List<Note> GetAllWithDetails()
    {
        var notes = _context.Notes
            .Include(x => x.NoteTags)
            .Include(x => x.NoteBlocks)
            .OrderByDescending(x => x.UpdatedDate ?? x.CreatedDate)
            .ToList();

        foreach (var note in notes)
        {
            if (note.NoteBlocks != null)
                note.NoteBlocks = note.NoteBlocks.OrderBy(x => x.OrderIndex).ToList();
        }

        return notes;
    }

    public Note GetNoteWithDetails(int id)
    {
        var note = _context.Notes
            .Include(x => x.NoteTags)
            .Include(x => x.NoteBlocks)
            .FirstOrDefault(x => x.NoteId == id);

        if (note != null && note.NoteBlocks != null)
            note.NoteBlocks = note.NoteBlocks.OrderBy(x => x.OrderIndex).ToList();

        return note;
    }

    public void SaveNote(Note note)
{
    if (note.NoteId > 0)
    {
        var existingNote = _context.Notes
            .Include(x => x.NoteTags)
            .Include(x => x.NoteBlocks)
            .FirstOrDefault(x => x.NoteId == note.NoteId);

        if (existingNote == null)
            throw new Exception("Güncellenecek not bulunamadı.");

        existingNote.Title = note.Title;
        existingNote.Category = note.Category;
        existingNote.UpdatedDate = DateTime.Now;
        existingNote.Status = true;

        if (existingNote.NoteTags != null && existingNote.NoteTags.Any())
            _context.NoteTags.RemoveRange(existingNote.NoteTags);

        if (existingNote.NoteBlocks != null && existingNote.NoteBlocks.Any())
            _context.NoteBlocks.RemoveRange(existingNote.NoteBlocks);

        _context.SaveChanges();

        if (note.NoteTags != null)
        {
            foreach (var tag in note.NoteTags)
            {
                _context.NoteTags.Add(new NoteTag
                {
                    NoteId = existingNote.NoteId,
                    TagName = tag.TagName
                });
            }
        }

        if (note.NoteBlocks != null)
        {
            foreach (var block in note.NoteBlocks.OrderBy(x => x.OrderIndex))
            {
                _context.NoteBlocks.Add(new NoteBlock
                {
                    NoteId = existingNote.NoteId,
                    Type = block.Type,
                    Content = block.Content,
                    Lang = block.Lang,
                    OrderIndex = block.OrderIndex
                });
            }
        }

        _context.SaveChanges();
    }
    else
    {
        var newNote = new Note
        {
            Title = note.Title,
            Category = note.Category,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            Status = true,
        };

        _context.Notes.Add(newNote);
        _context.SaveChanges();

        if (note.NoteTags != null)
        {
            foreach (var tag in note.NoteTags)
            {
                _context.NoteTags.Add(new NoteTag
                {
                    NoteId = newNote.NoteId,
                    TagName = tag.TagName
                });
            }
        }

        if (note.NoteBlocks != null)
        {
            foreach (var block in note.NoteBlocks.OrderBy(x => x.OrderIndex))
            {
                _context.NoteBlocks.Add(new NoteBlock
                {
                    NoteId = newNote.NoteId,
                    Type = block.Type,
                    Content = block.Content,
                    Lang = block.Lang,
                    OrderIndex = block.OrderIndex
                });
            }
        }

        _context.SaveChanges();

        note.NoteId = newNote.NoteId;
    }
}
}