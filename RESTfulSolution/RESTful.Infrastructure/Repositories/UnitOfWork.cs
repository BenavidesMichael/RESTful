using RESTful.Core.Entities;
using RESTful.Core.Interfaces;
using RESTful.Infrastructure.Data;
using System.Threading.Tasks;

namespace RESTful.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // UnitOfWork va se charger de faire touts les saves vers la DB
        private readonly RestFulContext _db;
        private readonly IPostRepository _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;


        public UnitOfWork(RestFulContext db)
        {
            this._db = db;
        }


        // le contexte sera toujour ke le mm, pour que plus tard on puisse utiliser les transactions.
        public IPostRepository PostRepository => this._postRepository ?? new PostRepository(this._db);
        public IRepository<User> UserRepository => this._userRepository ?? new BaseRepository<User>(this._db);
        public IRepository<Comment> CommentRepository => this._commentRepository ?? new BaseRepository<Comment>(this._db);



        public async Task SaveChangesAsync()
        {
            await this._db.SaveChangesAsync();
        }


        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }

    }
}
