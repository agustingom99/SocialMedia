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
    public class UserRepository : IUserRepository
    {
        private readonly SocialMediaContext _contex;
        public UserRepository(SocialMediaContext contex)
        {
            _contex = contex;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var User = await _contex.Users.ToListAsync();

            await Task.Delay(10);
            return User;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _contex.Users.FirstOrDefaultAsync(x => x.UserId == id);

            await Task.Delay(10);
            return user;
        }
    }
}
