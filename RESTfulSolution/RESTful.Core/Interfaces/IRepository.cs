using RESTful.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTful.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int Id);
        Task CreateAsync(T model);
        void Update(T model);
        Task DeleteAsync(int Id);
    }
}
