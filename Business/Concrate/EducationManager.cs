using Business.Abstract;
using Data_Access_Layer.Abstract;
using Dto.Portfolio;
using Entities.Concrate;

namespace Business.Concrate;

public class EducationManager:IEducationService
{
    private readonly IEducationDal _educationDal;
    public EducationManager(IEducationDal educationDal)
    {
        _educationDal = educationDal;
    }
    public void Insert(Education t)
    {
        _educationDal.Insert(t);
    }

    public void Update(Education t)
    {
       _educationDal.Update(t);
    }

    public void Delete(Education t)
    {
        _educationDal.Delete(t);  
    }

    public List<Education> GetAll()
    {
        return _educationDal.GetAll(); 
    }

    public Education GetById(int id)
    {
        return _educationDal.GetById(id);
    }
}