using SocialMedia_Core.Entities;
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
        public  async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _contex.Posts.ToListAsync();

            await Task.Delay(10);
            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _contex.Posts.FirstOrDefaultAsync(x=> x.PostId == id);

            await Task.Delay(10);
            return post;
        }

        public async Task InsertPost(Post post)
        {
            _contex.Posts.Add(post);
            await _contex.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var currentPost = await GetPost(post.PostId);
            currentPost.Date = post.Date;
            currentPost.Description = post.Description;
            currentPost.Image = post.Image;

            int rows = await _contex.SaveChangesAsync();
            return rows > 0; // si se generaron actualizaciones devuelve true

        }

        public async Task<bool> DeletePost(int  id)
        {
            var currentPost = await GetPost(id);
            _contex.Posts.Remove(currentPost);

            int rows = await _contex.SaveChangesAsync();
            return rows > 0; // si se generaron actualizaciones devuelve true

        }



    }
}
