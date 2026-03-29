namespace MyBlog.Dtos;

public class NoteSaveDto
{
    public int? NoteId { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public List<string> Tags { get; set; } = new();
    public List<NoteBlockDto> Blocks { get; set; } = new();
}