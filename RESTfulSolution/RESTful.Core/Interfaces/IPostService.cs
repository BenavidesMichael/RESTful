using RESTful.Core.Entities;
using RESTful.Core.Helper;
using RESTful.Core.QueryFilters;
using System.Threading.Tasks;

namespace RESTful.Core.Interfaces
{
    public interface IPostService
    {
        PagedListHelper<Post> GetAllPosts(PostFilter model);
        Task<Post> GetByIdAsync(int id);
        Task CreateAsync(Post model);
        Task UpdateAsync(Post model);
        Task DeleteAsync(int Id);
    }
}
