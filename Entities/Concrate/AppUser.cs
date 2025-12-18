using Microsoft.AspNetCore.Identity;

namespace Entities.Concrate;

public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}