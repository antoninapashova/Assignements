using Domain.Entity;
using Hobby_Project;
using HobbyProject.Domain.Entity;
using Microsoft.AspNetCore.Hosting.Server;
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
        public DbSet<HobbyEntity> HobbyEntities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public HobbyDbContext() : base(){ }
        public HobbyDbContext(DbContextOptions<HobbyDbContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = @"Server=DESKTOP-AI1LMFV\SQLEXPRESS;Database = HobbyDB;Trusted_Connection=SSPI;Encrypt = false;TrustServerCertificate=true";
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn);
            }
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<HobbyEntity>(a =>
            {
                a.HasMany(x => x.HobbyComments).WithOne(x => x.HobbyArticle)
                .HasForeignKey(x => x.HobbyArticleId).OnDelete(DeleteBehavior.Cascade);

                a.HasMany(x => x.HobbyPhoto).WithOne(x => x.HobbyArticle)
                .HasForeignKey(c => c.HobbyArticleId).OnDelete(DeleteBehavior.Cascade);

                a.HasMany(t => t.Tags).WithMany(h => h.HobbyArticles);

                a.HasOne(x => x.User).WithMany(x => x.Hobbies).HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<UserEntity>(u =>
            {
                u.HasMany(x => x.Hobbies).WithOne(x => x.User)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

                u.HasMany(x => x.Comments).WithOne(x => x.User)
                 .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            });

           
           
        }
    }
}
