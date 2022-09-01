using Microsoft.EntityFrameworkCore;
using SocialMedia.Infrastructure.Data;
using SocialMedia_Core.Entities;
using SocialMedia_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _contex;
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        public UnitOfWork(SocialMediaContext contex)
        {
            _contex = contex;
        }

        public IRepository<Post> PostRepository => _postRepository ?? new BaseRepository<Post>(_contex) ;

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_contex);

        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_contex);

        public void Dispose()
        {
            if(_contex != null)
            {
                _contex.Dispose();  
            };
        }

        public void saveChanges()
        {
            _contex.SaveChanges();
        }

        public async Task saveChangesAsync()
        {
            await _contex.SaveChangesAsync();
        }
    }
}
