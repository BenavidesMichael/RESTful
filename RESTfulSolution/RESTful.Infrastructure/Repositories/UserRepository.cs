using Microsoft.EntityFrameworkCore;
using RESTful.Core.Entities;
using RESTful.Core.Interfaces;
using RESTful.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RestFulContext _db;

        public UserRepository(RestFulContext db)
        {
            this._db = db;
        }


        public async Task<IEnumerable<User>> GetAllPosts()
        {
            try
            {
                var result = await _db.Users.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<User> GetById(int id)
        {
            try
            {
                return await _db.Users.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
