using Entities.Concrate;

namespace Business.Abstract;

public interface IBlogService:IGenericService<Blog>
{
    public List<Blog> TGetListWithCategory();
    void TChangeStatus(int id);
    public List<Blog> TGetListWithStatus();

}