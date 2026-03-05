using Data_Access_Layer.Abstract;
using Data_Access_Layer.Contexts;
using DataAccess.Concrate.Repository;
using Entities.Concrate;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfEducationDal:GenericRepository<Education>,IEducationDal
{
    public EfEducationDal(BlogContexts context) : base(context)
    {
    }
}