using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using DataAccess.Concrate.Repository;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfBlogDal:GenericRepository<Blog>,IBlogDal
{
    public List<Blog> GetListWithCategory()
    {
        using var contexts = new BlogContexts();
        return contexts.Blogs.Include(x => x.Category).ToList();
    }

    public void ChangeStatus(int id)
    {
        using var context = new BlogContexts();
        var value = context.Blogs.Find(id);
        if (value.BlogStatus == true)
        {
            value.BlogStatus = false;
            context.SaveChanges();
        }
        else
        {
            value.BlogStatus = true;
            context.SaveChanges();
        }
    }

    public List<Blog> GetListWithStatus()
    {
        using var contexts = new BlogContexts();
        return contexts.Blogs.Where(x => x.BlogStatus == true).Include(y=>y.Category).ToList();
    }
}