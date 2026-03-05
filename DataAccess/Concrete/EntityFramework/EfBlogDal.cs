using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using DataAccess.Concrate.Repository;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfBlogDal:GenericRepository<Blog>,IBlogDal
{
    private readonly BlogContexts _context;
    public EfBlogDal(BlogContexts context) : base(context)
    {
        _context = context;
    }

    public List<Blog> GetListWithCategory()
    {
        return _context.Blogs.Include(x => x.Category).ToList();
    }

    public void ChangeStatus(int id)
    {
        var value = _context.Blogs.Find(id);
        if (value.BlogStatus == true)
        {
            value.BlogStatus = false;
            _context.SaveChanges();
        }
        else
        {
            value.BlogStatus = true;
            _context.SaveChanges();
        }
    }

    public List<Blog> GetListWithStatus()
    {
        return _context.Blogs.Where(x => x.BlogStatus == true).Include(y=>y.Category).ToList();
    }
}