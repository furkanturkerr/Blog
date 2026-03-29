using Entities.Concrate;

namespace Business.Abstract;

public interface INoteService : IGenericService<Note>
{
    List<Note> GetAllWithDetails();
    Note GetNoteWithDetails(int id);
    void SaveNote(Note note);
}