using Entities.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Contexts;

public class BlogContexts :  IdentityDbContext<AppUser, AppRole, int>
{
    public BlogContexts(DbContextOptions<BlogContexts> options) : base(options)
    {
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
    
    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteBlock> NoteBlocks { get; set; }
    public DbSet<NoteTag> NoteTags { get; set; }
}