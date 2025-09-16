using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate.Repository;

public class GenericRepository<T> : IGenericDal<T> where T : class, new()
{
    public void Insert(T t)
    {
        using var context = new BlogContexts();
        context.Add(t);
        context.SaveChanges();
    }

    public void Update(T t)
    {
        using var context = new BlogContexts();
        context.Update(t);
        context.SaveChanges();
    }

    public void Delete(T t)
    {
        using var context = new BlogContexts();
        context.Remove(t);
        context.SaveChanges();
    }

    public List<T> GetAll()
    {
        using var context = new BlogContexts();
        return context.Set<T>().ToList();
    }

    public T GetById(int id)
    {
        using var context = new BlogContexts();
        return context.Set<T>().Find(id);
    }
}