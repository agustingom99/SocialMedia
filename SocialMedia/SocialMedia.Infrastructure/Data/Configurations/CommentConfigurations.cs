using Microsoft.EntityFrameworkCore;
using SocialMedia_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comentario");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("idComentario")
            .ValueGeneratedNever();

            builder.Property(e => e.PostId).HasColumnName("IdPublicacion");


            builder.Property(e => e.UserId).HasColumnName("IdUsuario")
          ;
            builder.Property(e => e.IsActive).HasColumnName("Activo")
         ;

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("Descripcion")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date).HasColumnName("Fecha").HasColumnType("datetime");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Publicacion");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
            
        }
    }
}
