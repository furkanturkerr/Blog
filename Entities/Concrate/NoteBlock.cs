namespace Entities.Concrate;

public class NoteBlock
{
    public int NoteBlockId { get; set; }

    public int NoteId { get; set; }
    public Note Note { get; set; }

    public string Type { get; set; }    
    public string Content { get; set; }
    public string? Lang { get; set; }    
    public int OrderIndex { get; set; }
}