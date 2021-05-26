using RESTful.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTful.Core.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        Task<Post> GetByIdAsync(int id);
        Task CreateAsync(Post model);
        Task UpdateAsync(Post model);
        Task DeleteAsync(int Id);
    }
}
