using Business.Abstract;
using Data_Access_Layer.Abstract;
using Dto.Portfolio;
using Entities.Concrate;

namespace Business.Concrate;

public class ServiceManager:IServiceService
{
    private readonly IServiceDal _servicedAL;
    public ServiceManager(IServiceDal servicedal)
    {
        _servicedAL = servicedal;
    }
    public void Insert(Service t)
    {
        _servicedAL.Insert(t);
    }

    public void Update(Service t)
    {
        _servicedAL.Update(t);
    }

    public void Delete(Service t)
    {
        _servicedAL.Delete(t);
    }

    public List<Service> GetAll()
    {
        return _servicedAL.GetAll();
    }

    public Service GetById(int id)
    {
        return _servicedAL.GetById(id);
    }
}