using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialMedia_Core.Entities;
namespace SocialMedia_Core.Interfaces
{
    // nos representa las operaciones que vamos a realizar contra la base de datos 
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();

        Task<Post> GetPost(int id);

        Task InsertPost(Post post);

        Task <bool>  DeletePost(int id);

        Task <bool> UpdatePost(Post post);
    }
}
