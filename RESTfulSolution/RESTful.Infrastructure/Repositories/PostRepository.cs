using Microsoft.EntityFrameworkCore;
using RESTful.Core.Entities;
using RESTful.Core.Interfaces;
using RESTful.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {

        public PostRepository(RestFulContext db) : base(db)
        {
        }


        public async Task<IEnumerable<Post>> GetAllPostsByUser(int userId)
        {
            return await _entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
