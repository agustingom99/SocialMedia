using SocialMedia_Core.CustomEntities;
using SocialMedia_Core.Entities;
using SocialMedia_Core.QueryFilters.cs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia_Core.Interfaces
{
    public interface IPostServices
    {
        PagedList<Post> GetPosts(PostQueryFilter filters);
        Task InsertPost(Post post);




        Task<Post> GetPost(int id);

        Task<bool> DeletePost(int id);

        Task<bool> UpdatePost(Post post);
    }
}
