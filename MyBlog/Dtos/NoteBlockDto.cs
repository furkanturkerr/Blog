namespace MyBlog.Dtos;

public class NoteBlockDto
{
    public string Type { get; set; }
    public string Content { get; set; }
    public string? Lang { get; set; }
    public int OrderIndex { get; set; }
}