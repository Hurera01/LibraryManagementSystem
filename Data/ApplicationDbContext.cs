using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using System.Reflection.Emit;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Books> books { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Book_Category> Book_Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .HasOne(b => b.Authors)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.author_id);

            modelBuilder.Entity<Book_Category>()
                .HasKey(bc => new { bc.book_id, bc.category_id });

            modelBuilder.Entity<Book_Category>()
                .HasOne(b => b.Categories)
                .WithMany(c => c.Book_Categories)
                .HasForeignKey(b => b.category_id);

            modelBuilder.Entity<Book_Category>()
                .HasOne(b => b.Books)
                .WithMany(c => c.Book_Categories)
                .HasForeignKey(b => b.book_id);

            modelBuilder.Entity<Loans>()
                .HasOne(l => l.Books)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.book_id);

            modelBuilder.Entity<Loans>()
                .HasOne(m => m.Members)
                .WithMany(l => l.Loans)
                .HasForeignKey(l => l.member_id);
        }
    }
}

