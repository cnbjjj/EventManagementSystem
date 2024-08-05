using EventManagementSystem.DAL;

namespace EventManagementSystem.BLL
{
    public interface IGenericService<M,D>: IGenericDAL<M>  where M : class where D : class
    {
    }
}
