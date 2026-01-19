using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models;

public class ImagesViewModel
{
    public int ImagesId { get; set; }
    
    [Required(ErrorMessage = "Lütfen bir görsel seçin")]
    public IFormFile Image { get; set; }
    public string? ImagePath { get; set; }
}