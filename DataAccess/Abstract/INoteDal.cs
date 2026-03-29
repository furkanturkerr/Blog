using Entities.Concrate;

namespace Data_Access_Layer.Abstract;

public interface INoteDal : IGenericDal<Note>
{
    List<Note> GetAllWithDetails();
    Note GetNoteWithDetails(int id);
    void SaveNote(Note note);
}