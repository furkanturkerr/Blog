using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class BlogManager : IBlogService
{
    private readonly IBlogDal _blogDal;
    public BlogManager(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }
    public void Insert(Blog t)
    {
        _blogDal.Insert(t);
    }

    public void Update(Blog t)
    {
        _blogDal.Update(t);
    }

    public void Delete(Blog t)
    {
        _blogDal.Delete(t);
    }

    public List<Blog> GetAll()
    {
        return _blogDal.GetAll();
    }

    public Blog GetById(int id)
    {
        return _blogDal.GetById(id);
    }
}