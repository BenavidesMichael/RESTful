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
    public class PostRepository : IPostRepository
    {
        private readonly RestFulContext _db;

        public PostRepository(RestFulContext db)
        {
            this._db = db;
        }


        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            try
            {
                var result = await _db.Posts.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<Post> GetById(int id)
        {
            try
            {
                return await _db.Posts.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task Create(Post model)
        {
            try
            {
                await _db.Posts.AddAsync(model);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<bool> Update(Post model)
        {
            try
            {
                var currentPost = await GetById(model.Id);
                currentPost.Date = model.Date;
                currentPost.Description = model.Description;
                currentPost.Image = model.Image;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public async Task<bool> Delete(int Id)
        {
            try
            {
                var currentPost = await GetById(Id);
                _db.Posts.Remove(currentPost);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
