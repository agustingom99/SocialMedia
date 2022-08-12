using SocialMedia_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository
    {
        public IEnumerable<Post> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post
            {
                PostId = x,
                Description = $"Description {x}",
                Date = DateTime.Now,
                Image = $"https://miapi.com {x}",
                UserId = x * 2
            });
            return posts;
        }
    }
}
