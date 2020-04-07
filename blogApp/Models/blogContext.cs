using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace blogApp.Models
{
    public partial class blogContext : DbContext
    {
        public blogContext()
        {
        }

        public blogContext(DbContextOptions<blogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG365;Database=blogApp;User Id=sa;Password=P@ssword01;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.PostData)
                    .IsRequired()
                    .HasColumnName("postData")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostHeading)
                    .IsRequired()
                    .HasColumnName("postHeading")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostUrl)
                    .HasColumnName("postUrl")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
