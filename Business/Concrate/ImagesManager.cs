using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class ImagesManager : IImagesService
{
    private readonly IImagesDal _imagesDal;

    public ImagesManager(IImagesDal imagesDal)
    {
        _imagesDal = imagesDal;
    }

    public void Insert(Images t)
    {
        _imagesDal.Insert(t);
    }

    public void Update(Images t)
    {
        _imagesDal.Update(t);
    }

    public void Delete(Images t)
    {
        _imagesDal.Delete(t);
    }

    public List<Images> GetAll()
    {
        return _imagesDal.GetAll();
    }

    public Images GetById(int id)
    {
        return _imagesDal.GetById(id);
    }
}