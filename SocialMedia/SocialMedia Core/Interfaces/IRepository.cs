using SocialMedia_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {

        Task<IEnumerable<T>> GetByAll();

        Task<T> GetById(int id);

        Task<T> Add(int id);

        Task<T> update(int id);

        Task Delete(int id);

            

    }
}
