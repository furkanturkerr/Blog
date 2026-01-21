using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class PortfolioManager:IPortfolioService
{
    private readonly IPortfolioDal _portfolioDal;
    public PortfolioManager(IPortfolioDal portfolioDal)
    {
        _portfolioDal = portfolioDal;
    }
    public void Insert(Portfolio t)
    {
        _portfolioDal.Insert(t);
    }

    public void Update(Portfolio t)
    {
        _portfolioDal.Update(t);
    }

    public void Delete(Portfolio t)
    {
        _portfolioDal.Delete(t);
    }

    public List<Portfolio> GetAll()
    {
        return _portfolioDal.GetAll();
    }

    public Portfolio GetById(int id)
    {
        return _portfolioDal.GetById(id);
    }

    public void TChageStatus(int id)
    {
        _portfolioDal.ChageStatus(id);
    }

    public List<Portfolio> TListStatusTrue()
    {
        return _portfolioDal.ListStatusTrue();
    }
}