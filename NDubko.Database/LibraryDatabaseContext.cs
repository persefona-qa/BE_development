using Microsoft.EntityFrameworkCore;
using NDubko.Domain;

namespace NDubko.Database;

public class LibraryDatabaseContext : DbContext
{
    public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(author => author.Books)
            .WithOne(book => book.Author)
            .HasForeignKey(book => book.AuthorId);
    }
}