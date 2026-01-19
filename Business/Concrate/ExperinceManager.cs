using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class ExperinceManager:IExperinceService
{
    private readonly IExperinceDal _experinceDal;
    public ExperinceManager(IExperinceDal experinceDal)
    {
        _experinceDal = experinceDal;
    }
    
    public void Insert(Experience t)
    {
        _experinceDal.Insert(t);
    }

    public void Update(Experience t)
    {
        _experinceDal.Update(t);
    }

    public void Delete(Experience t)
    {
       _experinceDal.Delete(t);   
    }

    public List<Experience> GetAll()
    {
        return _experinceDal.GetAll();   
    }

    public Experience GetById(int id)
    {
        return _experinceDal.GetById(id);  
    }
}