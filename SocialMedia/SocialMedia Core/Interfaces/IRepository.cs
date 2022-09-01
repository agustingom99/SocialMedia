using SocialMedia_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {

        IEnumerable<T> GetByAll();

        Task<T> GetById( int id);

        Task Add(T entity);

        void update(T entity);

        Task Delete(int id);

            

    }
}
