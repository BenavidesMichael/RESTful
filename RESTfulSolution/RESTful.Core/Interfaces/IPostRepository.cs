using RESTful.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTful.Core.Interfaces
{
    public interface IPostRepository : IRepository<Post> 
    {
        Task<IEnumerable<Post>> GetAllPostsByUser(int userId);
    }
}
