﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HobbyProject.Infrastructure.Migrations
{
    [DbContext(typeof(HobbyDbContext))]
    [Migration("20230125222227_updateHobbyComemntTable")]
    partial class updateHobbyComemntTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.HobbyArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HobbySubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HobbySubCategoryId");

                    b.ToTable("HobbyArticles");
                });

            modelBuilder.Entity("Domain.Entity.HobbyPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HobbyArticleId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HobbyArticleId");

                    b.ToTable("HobbyPhotos");
                });

            modelBuilder.Entity("HobbyArticleTag", b =>
                {
                    b.Property<int>("HobbyArticlesId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("HobbyArticlesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("HobbyArticleTag");
                });

            modelBuilder.Entity("Hobby_Project.HobbyCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HobbyCategories");
                });

            modelBuilder.Entity("Hobby_Project.HobbyComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HobbyArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HobbyArticleId");

                    b.ToTable("HobbyComments");
                });

            modelBuilder.Entity("Hobby_Project.HobbySubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HobbyCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HobbyCategoryId");

                    b.ToTable("HobbySubCategories");
                });

            modelBuilder.Entity("Hobby_Project.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Domain.Entity.HobbyArticle", b =>
                {
                    b.HasOne("Hobby_Project.HobbySubCategory", "HobbySubCategory")
                        .WithMany("HobbyArticles")
                        .HasForeignKey("HobbySubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HobbySubCategory");
                });

            modelBuilder.Entity("Domain.Entity.HobbyPhoto", b =>
                {
                    b.HasOne("Domain.Entity.HobbyArticle", "HobbyArticle")
                        .WithMany("HobbyPhoto")
                        .HasForeignKey("HobbyArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HobbyArticle");
                });

            modelBuilder.Entity("HobbyArticleTag", b =>
                {
                    b.HasOne("Domain.Entity.HobbyArticle", null)
                        .WithMany()
                        .HasForeignKey("HobbyArticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hobby_Project.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hobby_Project.HobbyComment", b =>
                {
                    b.HasOne("Domain.Entity.HobbyArticle", "HobbyArticle")
                        .WithMany("HobbyComments")
                        .HasForeignKey("HobbyArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HobbyArticle");
                });

            modelBuilder.Entity("Hobby_Project.HobbySubCategory", b =>
                {
                    b.HasOne("Hobby_Project.HobbyCategory", "HobbyCategory")
                        .WithMany("HobbySubCategories")
                        .HasForeignKey("HobbyCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HobbyCategory");
                });

            modelBuilder.Entity("Domain.Entity.HobbyArticle", b =>
                {
                    b.Navigation("HobbyComments");

                    b.Navigation("HobbyPhoto");
                });

            modelBuilder.Entity("Hobby_Project.HobbyCategory", b =>
                {
                    b.Navigation("HobbySubCategories");
                });

            modelBuilder.Entity("Hobby_Project.HobbySubCategory", b =>
                {
                    b.Navigation("HobbyArticles");
                });
#pragma warning restore 612, 618
        }
    }
}
