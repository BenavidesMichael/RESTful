using RESTful.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTful.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllPosts();
        Task<User> GetById(int id);
    }
}
