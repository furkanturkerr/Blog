using Entities.Concrate;

namespace Data_Access_Layer.Abstract;

public interface IPortfolioDal:IGenericDal<Portfolio>
{
    void ChageStatus(int id);
    List<Portfolio> ListStatusTrue();
}