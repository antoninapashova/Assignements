using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllEntitiesAsync();
    }
}
