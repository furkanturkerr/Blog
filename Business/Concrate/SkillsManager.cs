using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class SkillsManager:ISkillsService
{
    private readonly ISkilsDal _skillsDal;
    public SkillsManager(ISkilsDal skillsDal)
    {
        _skillsDal = skillsDal;
    }
    public void Insert(Skills t)
    {
        _skillsDal.Insert(t);   
    }

    public void Update(Skills t)
    {
       _skillsDal.Update(t);
    }

    public void Delete(Skills t)
    {
        _skillsDal.Delete(t);
    }

    public List<Skills> GetAll()
    {
      return _skillsDal.GetAll();  
    }

    public Skills GetById(int id)
    {
       return _skillsDal.GetById(id);
    }
}