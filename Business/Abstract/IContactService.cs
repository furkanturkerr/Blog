using Entities.Concrate;

namespace Business.Abstract;

public interface IContactService:IGenericService<Contact>
{
    public List<Contact> TListTrue();
    public List<Contact> TListFalse();
    
    void TChageStatusWithTrue(int id);
    void TChageStatusWithFalse(int id); 
}