using Application.Users.Commands.Create;
using Domain.Entity;
using Hobby_Project;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HobbyDbContext : DbContext
    {

        public DbSet<HobbyArticle> HobbyArticles { get; set; }
        public DbSet<HobbyCategory> HobbyCategories { get; set; }
        public DbSet<HobbyComment> HobbyComments { get; set; }
        public DbSet<HobbySubCategory> HobbySubCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public HobbyDbContext() : base()
        {
        }

        public HobbyDbContext(DbContextOptions<HobbyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                const string connectionString = "Server=DESKTOP-AI1LMFV\\SQLEXPRESS;Database=HobbyDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HobbyCategory>(hc =>
            {
                hc.Property(x => x.Name).IsRequired().HasMaxLength(12);

                hc.HasMany(x => x.HobbySubCategories).WithOne(x => x.HobbyCategory).HasForeignKey(x => x.HobbyCategoryId);

            });

            modelBuilder.Entity<HobbySubCategory>(sc =>
            {
                sc.Property(x => x.Name).IsRequired().HasMaxLength(12);

                sc.HasOne(x => x.HobbyCategory).WithMany(x => x.HobbySubCategories).HasForeignKey(x => x.HobbyCategoryId);
                sc.HasMany(x => x.HobbyArticles).WithOne(x => x.HobbySubCategory).HasForeignKey(x => x.HobbySubCategoryId);

            });
            modelBuilder.Entity<HobbyArticle>(a =>
            {
                a.Property(x => x.Title).IsRequired().HasMaxLength(15);
                a.Property(x => x.Description).IsRequired().HasMaxLength(200);

                a.HasOne(x => x.User).WithMany(x => x.Hobbies).HasForeignKey(x => x.UserId);
                a.HasOne(x => x.HobbySubCategory).WithMany(x => x.HobbyArticles).HasForeignKey(x => x.HobbySubCategoryId);
                a.HasMany(x => x.HobbyComments).WithOne(x => x.HobbyArticle).HasForeignKey(x => x.HobbyArticleId).OnDelete(DeleteBehavior.Cascade);
                a.HasMany(x => x.HobbyTags).WithOne(x => x.HobbyArticle).HasForeignKey(x => x.HobbyArticleId);
            });

            modelBuilder.Entity<HobbyComment>(c =>
            {
                c.Property(x => x.CommentContent).IsRequired().HasMaxLength(100);

                c.HasOne(x => x.HobbyArticle).WithMany(x => x.HobbyComments).HasForeignKey(x => x.HobbyArticleId);
                c.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

                //NB! The realtionship between User and Comment entities  
                //   -- One-To-Many or One-To-One?
            });

            modelBuilder.Entity<Tag>(t =>
            {
                t.Property(x => x.Name).IsRequired().HasMaxLength(12);
                t.HasMany(x => x.HobbyArticles).WithOne(x => x.Tag).HasForeignKey(x => x.TagId);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.Property(x => x.Username).IsRequired().HasMaxLength(10);
                u.Property(x => x.FirstName).IsRequired().HasMaxLength(10);
                u.Property(x => x.LastName).IsRequired().HasMaxLength(10);
                u.HasIndex(x => x.Email).IsUnique();
                u.Property(x => x.Age).IsRequired().HasMaxLength(2);

                u.HasMany(x => x.Hobbies).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ArticleTag>(at =>
            {
                at.HasKey(x => new { x.HobbyArticleId, x.TagId });
            });
        }
    }
}
