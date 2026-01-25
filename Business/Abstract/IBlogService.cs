using Entities.Concrate;

namespace Business.Abstract;

public interface IBlogService:IGenericService<Blog>
{
    public List<Blog> TGetListWithCategory();
}