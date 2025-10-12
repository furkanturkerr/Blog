using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models;

public class NavbarLeftViewModel
{
    
    public int NavbarLeftId { get; set; }
   
    public IFormFile NavbarLeftImage { get; set; }
    
    [Required(ErrorMessage = "Zorunlu Alan")]
    public string NavbarLefName { get; set; }
    
    [Required(ErrorMessage = "Zorunlu Alan")]
    public string NavbarLeftText { get; set; }
    
    [Required(ErrorMessage = "Zorunlu Alan")]
    public string NavbarLeftEmail { get; set; }
    
    [Required(ErrorMessage = "Zorunlu Alan")]
    public string NavbarLeftPhone { get; set; }
    
    [Required(ErrorMessage = "Zorunlu Alan")]
    public string NavbarLeftAddress { get; set; }
    
    [Required(ErrorMessage = "Zorunlu Alan")]
    public string NavbarLeftLinkGithub { get; set; }
    
    [Required(ErrorMessage = "Zorunlu Alan")]
    public string NavbarLeftLinkLinkedin { get; set; }
    
    [Required(ErrorMessage = "Zorunlu Alan")]
    public string NavbarLeftLinkInstagram { get; set; }
}