using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models;

public class UserUpdateViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ad alanı zorunludur")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Soyad alanı zorunludur")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
    public string Username { get; set; }

    [Required(ErrorMessage = "E-posta zorunludur")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz")]
    public string Mail { get; set; }
}