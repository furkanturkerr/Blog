using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using DataAccess.Concrate.Repository;
using Entities.Concrate;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfContactDal:GenericRepository<Contact>,IContactDal
{
    public List<Contact> ListTrue()
    {
        using var context = new BlogContexts();
        return context.Contacts.Where(x => x.Status == true).ToList();
    }

    public List<Contact> ListFalse()
    {
        using var context = new BlogContexts();
        return context.Contacts.Where(x => x.Status == false).ToList();
    }

    public void ChageStatusWithTrue(int id)
    {
        using var context = new BlogContexts();
        var value = context.Contacts.Find(id);
        value.Status = true;
        context.SaveChanges();
    }

    public void ChageStatusWithFalse(int id)
    {
        using var context = new BlogContexts();
        var value = context.Contacts.Find(id);
        value.Status = false;
        context.SaveChanges();
    }
}