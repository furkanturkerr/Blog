using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class ExperincePageManager:IExperincePageService
{
    private readonly IExprenicePageDal _experiencePage;
    public ExperincePageManager(IExprenicePageDal experiencePage)
    {
        _experiencePage = experiencePage;
    }
    public void Insert(ExperiencePage t)
    {
        _experiencePage.Insert(t);
    }

    public void Update(ExperiencePage t)
    {
       _experiencePage.Update(t);
    }

    public void Delete(ExperiencePage t)
    {
        _experiencePage.Delete(t);
    }

    public List<ExperiencePage> GetAll()
    {
       return _experiencePage.GetAll();
    }

    public ExperiencePage GetById(int id)
    {
        return _experiencePage.GetById(id);
    }
}