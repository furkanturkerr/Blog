using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models;

public class UserRegisterViewModel
{
    [Required(ErrorMessage = "Lütfen İsim Değeri Giriniz")]
    [Display(Name = "İsim")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Lütfen Soyisim Değeri Giriniz")]
    [Display(Name = "Soyisim")]
    public string Surname { get; set; }
    
    [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
    [Display(Name = "Kullanıcı Adı")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Lütfen Email Değeri Giriniz")]
    [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz")]
    [Display(Name = "Email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Lütfen Parola Giriniz")]
    [MinLength(6, ErrorMessage = "Parola en az 6 karakter olmalıdır")]
    [Display(Name = "Parola")]
    public string Password { get; set; }
}
