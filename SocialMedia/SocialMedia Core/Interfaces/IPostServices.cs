using SocialMedia_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia_Core.Interfaces
{
    public interface IPostServices
    {
        Task InsertPost(Post post);

        IEnumerable<Post> GetPosts();

        Task<Post> GetPost(int id);

        Task<bool> DeletePost(int id);

        Task<bool> UpdatePost(Post post);
    }
}
