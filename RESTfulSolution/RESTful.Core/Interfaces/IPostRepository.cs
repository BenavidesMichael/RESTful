using RESTful.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTful.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<Post> GetById(int id);
        Task Create(Post model);
        Task<bool> Update(Post model);
        Task<bool> Delete(int Id);
    }
}
