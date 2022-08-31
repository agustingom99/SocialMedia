using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia_Core.Entities;
using System;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class PostConfigurations : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Publicacion");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("IdPublicacion");

            builder.Property(e => e.UserId).HasColumnName("IdUsuario");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("Descripcion")
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Date).HasColumnName("Fecha").HasColumnType("datetime");

            builder.Property(e => e.Image)
                .HasColumnName("imagen")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Usuario");
        }
    }
}
