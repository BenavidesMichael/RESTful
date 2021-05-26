using RESTful.Core.Entities;
using System;
using System.Threading.Tasks;

namespace RESTful.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // prop pour acceder depuis notre service au Repository.
        IPostRepository PostRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Comment> CommentRepository { get; }

        Task SaveChangesAsync();
    }
}
