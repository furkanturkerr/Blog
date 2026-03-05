using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using DataAccess.Concrate.Repository;
using Entities.Concrate;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfServiceDal:GenericRepository<Service>,IServiceDal
{
    public EfServiceDal(BlogContexts context) : base(context)
    {
    }
}