namespace Entities.Concrate;

public class Note
{
    public int NoteId { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool Status { get; set; } = true;

    public List<NoteBlock>? NoteBlocks { get; set; }
    public List<NoteTag>? NoteTags { get; set; }
}