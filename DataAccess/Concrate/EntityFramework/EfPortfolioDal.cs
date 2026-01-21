using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using DataAccess.Concrate.Repository;
using Entities.Concrate;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfPortfolioDal:GenericRepository<Portfolio>,IPortfolioDal
{
    public void ChageStatus(int id)
    {
        using var contexts = new BlogContexts();
        var values = contexts.Portfolios.Find(id);

        if (values.Status == true)
        {
            values.Status = false;
            contexts.SaveChanges();
        }
        else
        {
            values.Status = true;
            contexts.SaveChanges();
        }
    }

    public List<Portfolio> ListStatusTrue()
    {
        using var contexts = new BlogContexts();
        var values = contexts.Portfolios.Where(x => x.Status == true).ToList();
        return values;
    }
}