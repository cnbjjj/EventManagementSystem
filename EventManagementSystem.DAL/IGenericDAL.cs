namespace EventManagementSystem.DAL
{
    public interface IGenericDAL<M> where M : class
    {
        public virtual Task<List<M>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<M> GetAsync<I>(I id)
        {
            throw new NotImplementedException();
        }

        public virtual Task AddAsync(M m)
        {
            throw new NotImplementedException();
        }

        public virtual Task UpdateAsync(M m)
        {
            throw new NotImplementedException();
        }

        public virtual Task RemoveAsync(M m)
        {
            throw new NotImplementedException();
        }

        public virtual Task RemoveAsync<I>(I id)
        {
            throw new NotImplementedException();
        }

        public virtual M Get<I>(I id)
        {
            throw new NotImplementedException();
        }

        public virtual List<M> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual void Add(M m)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(M m)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(M m)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove<I>(I id)
        {
            throw new NotImplementedException();
        }
    }
}
