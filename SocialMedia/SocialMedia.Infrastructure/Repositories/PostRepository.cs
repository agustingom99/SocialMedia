﻿using SocialMedia_Core.Entities;
using SocialMedia_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository: IPostRepository 
    {
        public  async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post
            {
                PostId = x,
                Description = $"Description {x}",
                Date = DateTime.Now,
                Image = $"https://miapi.com {x}",
                UserId = x * 2
            });

            await Task.Delay(10);
            return posts;
        }

     
    }
}