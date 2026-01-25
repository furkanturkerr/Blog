using Entities.Concrate;

namespace Data_Access_Layer.Abstract;

public interface IBlogDal:IGenericDal<Blog>
{
    public List<Blog> GetListWithCategory();
}