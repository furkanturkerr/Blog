using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate.Repository;

public class GenericRepository<T> : IGenericDal<T> where T : class, new()
{
    private readonly BlogContexts _context;

    public GenericRepository(BlogContexts context)
    {
        _context = context;
    }
    
    public void Insert(T t)
    {
        _context.Add(t);
        _context.SaveChanges();
    }

    public void Update(T t)
    { 
        _context.Update(t);
        _context.SaveChanges();
    }

    public void Delete(T t)
    {
        _context.Remove(t);
        _context.SaveChanges();
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
}