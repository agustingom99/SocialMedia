using Microsoft.EntityFrameworkCore;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialMedia_Core.Entities;
using System.Linq;

namespace SocialMedia.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _contex;
        private DbSet<T> _entities;


        public BaseRepository(SocialMediaContext contex)
        {
            _contex = contex;
            _entities = contex.Set<T>();
        }

        public IEnumerable<T> GetByAll()
        {
            return  _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add (T entity) 
        {
            await _entities.AddAsync(entity);
           
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
           
        }

        public void update(T entity)
        {
           _contex.Update(entity); 
           
        }
    }
}
