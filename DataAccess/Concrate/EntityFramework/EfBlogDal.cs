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
}