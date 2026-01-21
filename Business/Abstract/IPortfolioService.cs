using Entities.Concrate;

namespace Business.Abstract;

public interface IPortfolioService:IGenericService<Portfolio>
{
    void TChageStatus(int id);
    List<Portfolio> TListStatusTrue();
}