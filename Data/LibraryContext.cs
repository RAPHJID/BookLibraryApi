using Microsoft.EntityFrameworkCore;
using BookLibraryApi.Models;

namespace BookLibraryApi.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {  
        }
        public virtual DbSet<Book> Books {get;set;}
        public virtual DbSet<Author> Authors {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade); 
        }
        
    }

}