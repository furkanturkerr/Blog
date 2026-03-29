using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Dtos;
using MyBlog.Models;

namespace MyBlog.Controllers;

[Authorize]
public class NotesController : Controller
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    public IActionResult Index()
    {
        var model = new NoteEditorViewModel
        {
            Notes = _noteService.GetAllWithDetails()
        };

        return View(model);
    }

    [HttpGet]
    public JsonResult GetNote(int id)
    {
        var note = _noteService.GetNoteWithDetails(id);

        if (note == null)
            return Json(new { success = false, message = "Not bulunamadı." });

        var tags = new List<string>();

        if (note.NoteTags != null)
        {
            foreach (var tag in note.NoteTags)
            {
                tags.Add(tag.TagName);
            }
        }

        var blocks = new List<object>();

        if (note.NoteBlocks != null)
        {
            foreach (var block in note.NoteBlocks.OrderBy(x => x.OrderIndex))
            {
                blocks.Add(new
                {
                    type = block.Type,
                    content = block.Content,
                    lang = block.Lang
                });
            }
        }

        return Json(new
        {
            success = true,
            note = new
            {
                noteId = note.NoteId,
                title = note.Title,
                category = note.Category,
                date = note.CreatedDate.ToString("yyyy-MM-dd"),
                tags = tags,
                blocks = blocks
            }
        });
    }

    [HttpPost]
    public JsonResult Save([FromBody] NoteSaveDto model)
    {
        if (model == null)
            return Json(new { success = false, message = "Veri alınamadı." });

        if (string.IsNullOrWhiteSpace(model.Title))
            model.Title = "Yeni Not";

        if (string.IsNullOrWhiteSpace(model.Category))
            model.Category = "Genel";

        var note = new Note
        {
            NoteId = model.NoteId ?? 0,
            Title = model.Title,
            Category = model.Category,
            Status = true,
            NoteTags = new List<NoteTag>(),
            NoteBlocks = new List<NoteBlock>()
        };

        if (model.Tags != null)
        {
            foreach (var tag in model.Tags.Distinct())
            {
                note.NoteTags.Add(new NoteTag
                {
                    TagName = tag
                });
            }
        }

        if (model.Blocks != null)
        {
            foreach (var block in model.Blocks.OrderBy(x => x.OrderIndex))
            {
                note.NoteBlocks.Add(new NoteBlock
                {
                    Type = block.Type,
                    Content = block.Content,
                    Lang = block.Lang,
                    OrderIndex = block.OrderIndex
                });
            }
        }

        _noteService.SaveNote(note);

        return Json(new
        {
            success = true,
            noteId = note.NoteId
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var note = _noteService.GetNoteWithDetails(id);

        if (note == null)
            return RedirectToAction("Index");

        _noteService.Delete(note);

        return RedirectToAction("Index");
    }
}