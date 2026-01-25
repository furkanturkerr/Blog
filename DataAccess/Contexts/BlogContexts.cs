using Entities.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Contexts;

public class BlogContexts :  IdentityDbContext<AppUser, AppRole, int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
           "Server=localhost,1995;Database=Blog;User Id=sa;Password=Furkan12*;TrustServerCertificate=True;");
            
        //optionsBuilder.UseSqlServer(
          //"Server=.\\MSSQLSERVER2019;Database=furk8287_site;User Id=furk8287_site;Password=Furkan123*;TrustServerCertificate=True;");


    }
    
    public DbSet<About> Abouts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<ExperiencePage> ExperiencePages { get; set; }
    public DbSet<NavbarLeft> NavbarLefts { get; set; }
    public DbSet<Projes> Projes { get; set; }
    public DbSet<Skills> Skills { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Google> Googles { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<Category> Categories { get; set; }
}