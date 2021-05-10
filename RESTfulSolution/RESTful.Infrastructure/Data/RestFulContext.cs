using Microsoft.EntityFrameworkCore;
using RESTful.Core.Entities;

namespace RESTful.Infrastructure.Data
{
    public class RestFulContext : DbContext
    {
        public RestFulContext(DbContextOptions<RestFulContext> options)
            : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}