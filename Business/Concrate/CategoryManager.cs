using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public void Insert(Category t)
    {
        _categoryDal.Insert(t);
    }

    public void Update(Category t)
    {
        _categoryDal.Update(t);
    }

    public void Delete(Category t)
    {
        _categoryDal.Delete(t);
    }

    public List<Category> GetAll()
    {
        return _categoryDal.GetAll();
    }

    public Category GetById(int id)
    {
        return _categoryDal.GetById(id);
    }
}