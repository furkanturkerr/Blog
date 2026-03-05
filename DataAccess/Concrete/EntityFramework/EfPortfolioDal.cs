using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using DataAccess.Concrate.Repository;
using Entities.Concrate;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfPortfolioDal:GenericRepository<Portfolio>,IPortfolioDal
{
    private readonly BlogContexts _context;

    public EfPortfolioDal(BlogContexts context) : base(context)
    {
        _context = context;
    }

    public void ChageStatus(int id)
    {
        var values = _context.Portfolios.Find(id);

        if (values.Status == true)
        {
            values.Status = false;
            _context.SaveChanges();
        }
        else
        {
            values.Status = true;
            _context.SaveChanges();
        }
    }

    public List<Portfolio> ListStatusTrue()
    {
        var values = _context.Portfolios.Where(x => x.Status == true).ToList();
        return values;
    }
}