﻿using SocialMedia_Core.Entities;
using SocialMedia_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository: IPostRepository 
    {
        private readonly SocialMediaContext _contex;
        public PostRepository(SocialMediaContext contex)
        {
            _contex = contex;
        }
        public  async Task<IEnumerable<Publicacion>> GetPosts()
        {
            var posts = await _contex.Publicacion.ToListAsync();

            await Task.Delay(10);
            return posts;
        }

     
    }
}
