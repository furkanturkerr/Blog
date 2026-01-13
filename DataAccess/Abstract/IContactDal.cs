using Entities.Concrate;

namespace Data_Access_Layer.Abstract;

public interface IContactDal:IGenericDal<Contact>
{
    public List<Contact> ListTrue();
    public List<Contact> ListFalse();
    
    void ChageStatusWithTrue(int id);
    void ChageStatusWithFalse(int id);
}