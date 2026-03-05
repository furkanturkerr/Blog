using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using DataAccess.Concrate.Repository;
using Entities.Concrate;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfContactDal:GenericRepository<Contact>,IContactDal
{
    private readonly BlogContexts _context;

    public EfContactDal(BlogContexts context) : base(context)
    {
        _context = context;
    }

    public List<Contact> ListTrue()
    {
        return _context.Contacts.Where(x => x.Status == true).ToList();
    }

    public List<Contact> ListFalse()
    {
        return _context.Contacts.Where(x => x.Status == false).ToList();
    }

    public void ChageStatusWithTrue(int id)
    {
        var value = _context.Contacts.Find(id);
        value.Status = true;
        _context.SaveChanges();
    }

    public void ChageStatusWithFalse(int id)
    {
        var value = _context.Contacts.Find(id);
        value.Status = false;
        _context.SaveChanges();
    }
}