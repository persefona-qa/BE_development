using Microsoft.EntityFrameworkCore;
using NDubko.Domain;
using System.Linq.Expressions;

namespace NDubko.Database.Repositories;

/// <summary>
/// Task for #4
/// Move all DAL(data access layer to Repositories), do not use dbContext in Controllers.
/// </summary>
public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDatabaseContext dbContext;

    public AuthorRepository(LibraryDatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    #region Task for #3
    public async Task<int> CreateAsync(Author author, CancellationToken cancellationToken)
    {
        await dbContext.Authors.AddAsync(author, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return author.Id;
    }

    public async Task UpdateAsync(Author author, CancellationToken cancellationToken)
    {
        var dbAuthor = await dbContext.Authors.FindAsync(author.Id, cancellationToken) 
            ?? throw new NullReferenceException();
        dbAuthor.FirstName = author.FirstName;
        dbAuthor.LastName = author.LastName;

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var dbAuthor = await dbContext.Authors.FindAsync(id, cancellationToken) 
            ?? throw new NullReferenceException();
        dbContext.Remove(dbAuthor);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    public Task<Author> GetById(int id, CancellationToken cancellationToken)
        => dbContext.Authors
            .Include(x => x.Books)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public Task<Author> GetByFilter(string firstName, string lastName, CancellationToken cancellationToken)
    {
        Expression<Func<Author, bool>> predicate = (x) => 
            (string.IsNullOrEmpty(firstName) || x.FirstName == firstName) && 
            (string.IsNullOrEmpty(lastName) || x.LastName == lastName);
        
        return dbContext.Authors
            .Include(x => x.Books)
            .FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public Task<List<Author>> GetAll(CancellationToken cancellationToken)
        =>  dbContext.Authors.Include(x => x.Books).ToListAsync(cancellationToken);
}