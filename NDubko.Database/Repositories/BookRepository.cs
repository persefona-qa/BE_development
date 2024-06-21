using Microsoft.EntityFrameworkCore;
using NDubko.Domain;
using System.Linq.Expressions;

namespace NDubko.Database.Repositories;

/// <summary>
/// Task for #4
/// Move all DAL(data access layer to Repositories), do not use dbContext in Controllers.
/// </summary>
public class BookRepository : IBookRepository
{
    private readonly LibraryDatabaseContext dbContext;

    public BookRepository(LibraryDatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    #region Task for #3
    public async Task<int> CreateAsync(Book book, CancellationToken cancellationToken)
    {
        await dbContext.Books.AddAsync(book);
        await dbContext.SaveChangesAsync(cancellationToken);

        return book.Id;
    }

    public async Task UpdateAsync(Book book, CancellationToken cancellationToken)
    {
        var dbBook = await dbContext.Books.FindAsync(book.Id, cancellationToken)
            ?? throw new NullReferenceException();
        dbBook.Title = book.Title;
        dbBook.Publisher = book.Publisher;

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var dbBook = await dbContext.Books.FindAsync(id, cancellationToken)
            ?? throw new NullReferenceException();
        dbContext.Remove(dbBook);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    public Task<Book> GetById(int id, CancellationToken cancellationToken)
    => dbContext.Books
        .Include(x => x.Author)
        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public Task<Book> GetByFilter(string title, string publisher, CancellationToken cancellationToken)
    {
        Expression<Func<Book, bool>> predicate = (x) =>
            (string.IsNullOrEmpty(title) || x.Title == title) &&
            (string.IsNullOrEmpty(publisher) || x.Publisher == publisher);

        return dbContext.Books
            .Include(x => x.Author)
            .FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public Task<List<Book>> GetAll(CancellationToken cancellationToken)
        => dbContext.Books.Include(x => x.Author).ToListAsync(cancellationToken);
}