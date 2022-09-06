using SocialMedia.Infrastructure.Repositories;
using SocialMedia_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia_Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        IRepository<User> UserRepository { get; }

        IRepository<Comment> CommentRepository { get; } 
        void saveChanges();
        Task saveChangesAsync();
    }
}
