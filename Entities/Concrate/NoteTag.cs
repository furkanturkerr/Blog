namespace Entities.Concrate;

public class NoteTag
{
    public int NoteTagId { get; set; }

    public int NoteId { get; set; }
    public Note Note { get; set; }

    public string TagName { get; set; }
}