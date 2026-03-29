using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class NoteManager : INoteService
{
    private readonly INoteDal _noteDal;

    public NoteManager(INoteDal noteDal)
    {
        _noteDal = noteDal;
    }

    public void Insert(Note t)
    {
        _noteDal.Insert(t);
    }

    public void Update(Note t)
    {
        _noteDal.Update(t);  
    }

    public void Delete(Note t)
    {
        _noteDal.Delete(t); 
    }

    public List<Note> GetAll()
    {
        return _noteDal.GetAll();
    }

    public Note GetById(int id)
    {
        return _noteDal.GetById(id);
    }
    
    
    public List<Note> GetAllWithDetails()
    {
        return _noteDal.GetAllWithDetails();
    }

    public Note GetNoteWithDetails(int id)
    {
        return _noteDal.GetNoteWithDetails(id);
    }

    public void SaveNote(Note note)
    {
        _noteDal.SaveNote(note);
    }
}