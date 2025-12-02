using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Contexts;

public class BlogContexts :  DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,59443;Database=Blog;User Id=sa;Password=Furkan12*;TrustServerCertificate=True;");
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
}