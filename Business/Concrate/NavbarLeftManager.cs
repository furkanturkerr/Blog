using Business.Abstract;
using Data_Access_Layer.Abstract;
using Entities.Concrate;

namespace Business.Concrate;

public class NavbarLeftManager:INavbarLeftService
{
    private readonly INavbarLeftDal _navbarLeftDal;
    public NavbarLeftManager(INavbarLeftDal navbarLeftDal)
    {
        _navbarLeftDal = navbarLeftDal;
    }
    
    public void Insert(NavbarLeft t)
    {
       _navbarLeftDal.Insert(t);
    }

    public void Update(NavbarLeft t)
    {
        _navbarLeftDal.Update(t);
    }

    public void Delete(NavbarLeft t)
    {
        _navbarLeftDal.Delete(t);   
    }

    public List<NavbarLeft> GetAll()
    {
       return _navbarLeftDal.GetAll();  
    }

    public NavbarLeft GetById(int id)
    { 
        return _navbarLeftDal.GetById(id); 
    }
}