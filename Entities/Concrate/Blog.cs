namespace Entities.Concrate;

public class Blog
{
    public int BlogId { get; set; }
    public string BlogImage { get; set; }
    public string BlogText { get; set; }
    public string BlogTitle { get; set; }
    public string BlogDate { get; set; }
    public string BlogAuthor { get; set; }
    public bool BlogStatus { get; set; }
    public string BlogSlug { get; set; }
    
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
}