using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class AbautManager:IAbautService
{
    private readonly IAbautDal _abautDal;
    
    public AbautManager(IAbautDal abautDal)
    {
        _abautDal = abautDal;
    }
    
    public void Insert(About t)
    {
        _abautDal.Insert(t);
    }

    public void Update(About t)
    {
        _abautDal.Update(t);
    }

    public void Delete(About t)
    {
        _abautDal.Delete(t);
    }

    public List<About> GetAll()
    {
        return _abautDal.GetAll();
    }

    public About GetById(int id)
    {
        return _abautDal.GetById(id);
    }
}