namespace Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void Delete(T entity);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAllEntities();
        Task<bool> FindById(int id);
    }
}
