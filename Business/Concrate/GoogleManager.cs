using Business.Abstract;
using Data_Access_Layer.Abstract;
using Dto.Portfolio;
using Entities.Concrate;

namespace Business.Concrate;

public class GoogleManager : IGoogleService
{
    private readonly IGoogleDal _googleDal;
    public GoogleManager(IGoogleDal googleDal)
    {
        _googleDal = googleDal;
    }
    public void Insert(Google t)
    {
        _googleDal.Insert(t);
    }

    public void Update(Google t)
    {
        _googleDal.Update(t);
    }

    public void Delete(Google t)
    {
        _googleDal.Delete(t);
    }

    public List<Google> GetAll()
    {
        return _googleDal.GetAll();
    }

    public Google GetById(int id)
    {
        return _googleDal.GetById(id);
    }
}