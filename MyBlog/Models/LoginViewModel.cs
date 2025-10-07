using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email gereklidir")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Parola gereklidir")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; } = false;

}