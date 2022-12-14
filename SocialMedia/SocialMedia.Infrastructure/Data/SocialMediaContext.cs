using Microsoft.EntityFrameworkCore;
using SocialMedia.Infrastructure.Data.Configurations;
using SocialMedia_Core.Entities;

namespace SocialMedia.Infrastructure.Data

{
    public partial class SocialMediaContext : DbContext
    {
        public SocialMediaContext()
        {

        }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.ApplyConfiguration(new CommentConfigurations());
            modelBuilder.ApplyConfiguration(new PostConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
          

           
        }

        
    }
}
