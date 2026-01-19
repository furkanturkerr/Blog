using Data_Access_Layer.Abstract;
using DataAccess.Concrate.Repository;
using Entities.Concrate;

namespace Data_Access_Layer.Concrate.EntityFramework;

public class EfImagesDal : GenericRepository<Images>, IImagesDal
{
    
}