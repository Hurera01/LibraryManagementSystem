﻿// <auto-generated />
using System;
using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250305074623_ImagetoBook")]
    partial class ImagetoBook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagementSystem.Models.Author", b =>
                {
                    b.Property<int>("author_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("author_id"));

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("author_id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Book_Category", b =>
                {
                    b.Property<int>("book_id")
                        .HasColumnType("int");

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.HasKey("book_id", "category_id");

                    b.HasIndex("category_id");

                    b.ToTable("Book_Categories");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Books", b =>
                {
                    b.Property<int>("book_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("book_id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("author_id")
                        .HasColumnType("int");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("image_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isbn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("publish_year")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("book_id");

                    b.HasIndex("author_id");

                    b.ToTable("books");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Categories", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"));

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("category_id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Loans", b =>
                {
                    b.Property<int>("loan_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("loan_id"));

                    b.Property<int>("book_id")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("due_date")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("loan_date")
                        .HasColumnType("date");

                    b.Property<int>("member_id")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("return_date")
                        .HasColumnType("date");

                    b.HasKey("loan_id");

                    b.HasIndex("book_id");

                    b.HasIndex("member_id");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Members", b =>
                {
                    b.Property<int>("member_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("member_id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("membership_date")
                        .HasColumnType("date");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("member_id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Book_Category", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.Books", "Books")
                        .WithMany("Book_Categories")
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Models.Categories", "Categories")
                        .WithMany("Book_Categories")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Books", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.Author", "Authors")
                        .WithMany("Books")
                        .HasForeignKey("author_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authors");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Loans", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.Books", "Books")
                        .WithMany("Loans")
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Models.Members", "Members")
                        .WithMany("Loans")
                        .HasForeignKey("member_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Books", b =>
                {
                    b.Navigation("Book_Categories");

                    b.Navigation("Loans");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Categories", b =>
                {
                    b.Navigation("Book_Categories");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Members", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
