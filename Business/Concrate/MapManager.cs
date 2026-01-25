using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class MapManager : IMapService
{
    private readonly IMapDal _mapDal;

    public MapManager(IMapDal mapDal)
    {
        _mapDal = mapDal;
    }

    public void Insert(Map t)
    {
        _mapDal.Insert(t);
    }

    public void Update(Map t)
    {
        _mapDal.Update(t);
    }

    public void Delete(Map t)
    {
        _mapDal.Delete(t);
    }

    public List<Map> GetAll()
    {
        return _mapDal.GetAll();
    }

    public Map GetById(int id)
    {
        return _mapDal.GetById(id);
    }
}