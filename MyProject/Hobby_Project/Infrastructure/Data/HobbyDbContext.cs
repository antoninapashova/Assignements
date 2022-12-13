using Application.Users.Commands.Create;
using Domain.Entity;
using Hobby_Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
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
        public DbSet<HobbyPhoto> HobbyPhotos { get; set; }

        public HobbyDbContext() { }
        public HobbyDbContext(DbContextOptions<HobbyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArticleTag>(at =>
            {
                at.HasKey(x => new { x.HobbyArticleId, x.TagId });
            });

            modelBuilder.Entity<HobbyCategory>(hc =>
            {
                hc.HasData(new HobbyCategory()
                {
                    Id = 1,
                    Name = "Sports",
                },
                new HobbyCategory()
                {
                    Id = 2,
                    Name = "Cooking"
                });
            });


            modelBuilder.Entity<HobbySubCategory>(sc =>
            {
                sc.HasData(new HobbySubCategory()
                {
                    Id = 1,
                    Name = "Voleyball",
                    HobbyCategoryId = 1,
                },
                new HobbySubCategory()
                {
                    Id = 2,
                    Name = "Salads",
                    HobbyCategoryId = 2,
                });
            });

            modelBuilder.Entity<Tag>(t =>
            {
                t.HasData(new Tag()
                {
                    Id = 1,
                    Name = "Outside sports",
                },
                new Tag()
                {
                    Id = 2,
                    Name = "Vegetariаn food",
                });
            });

            modelBuilder.Entity<HobbyArticle>(a =>
            {
                a.HasMany(x => x.HobbyComments).WithOne(x => x.HobbyArticle).HasForeignKey(x => x.HobbyArticleId).OnDelete(DeleteBehavior.Cascade);
                a.HasMany(x => x.HobbyPhoto).WithOne(x => x.HobbyArticle).HasForeignKey(x => x.HobbyArticleId).OnDelete(DeleteBehavior.Cascade);
               
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasMany(x => x.Hobbies).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
