using EventManagementSystem.DAL;

namespace EventManagementSystem.BLL
{
    public class GenericService<M, D>: IGenericService<M,D> where M : class where D : class, IGenericDAL<M>
    {
        protected readonly D _dal;
        public GenericService(D dal)
        {
            _dal = dal;
        }

        public M Get<I>(I id)
        {
            return _dal.Get(id);
        }

        public List<M> GetAll()
        {
            return _dal.GetAll();
        }

        public void Add(M m)
        {
            _dal.Add(m);
        }

        public void Update(M m)
        {
            _dal.Update(m);
        }

        public void Remove(M m)
        {
            _dal.Remove(m);
        }

        public void Remove<I>(I id)
        {
            _dal.Remove(id);
        }

    }
}
