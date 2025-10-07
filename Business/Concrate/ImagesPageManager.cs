using Business.Abstract;
using Data_Access_Layer.Abstract;
using Data_Access_Layer.Migrations;
using Entities.Concrate;

namespace Business.Concrate;

public class ImagesPageManager:IImagePageService
{
    private readonly IImagesPageDal _imagesPage;
    public ImagesPageManager(IImagesPageDal imagesPage)
    {
        _imagesPage = imagesPage;
    }
    public void Insert(ImagesPage t)
    {
       _imagesPage.Insert(t);
    }

    public void Update(ImagesPage t)
    {
        _imagesPage.Update(t);
    }

    public void Delete(ImagesPage t)
    {
        _imagesPage.Delete(t);
    }

    public List<ImagesPage> GetAll()
    {
        return _imagesPage.GetAll();
    }

    public ImagesPage GetById(int id)
    {
        return _imagesPage.GetById(id);
    }
}