using Microsoft.EntityFrameworkCore;
using RESTful.Core.Entities;
using RESTful.Core.Interfaces;
using RESTful.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly RestFulContext _db;
        protected DbSet<T> _entities;

        public BaseRepository(RestFulContext db)
        {
            this._db = db;
            this._entities = _db.Set<T>();
        }


        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }


        public async Task<T> GetByIdAsync(int Id)
        {
            return await _entities.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }


        public async Task CreateAsync(T model)
        {
            await _entities.AddAsync(model);
        }


        public void Update(T model)
        {
            _entities.Update(model);
        }


        public async Task DeleteAsync(int Id)
        {
            T currentModel = await this.GetByIdAsync(Id);
            _entities.Remove(currentModel);
        }

    }
}
