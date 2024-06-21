using NDubko.Domain;

namespace NDubko.Database.Repositories;

public interface IBookRepository
{
    Task<int> CreateAsync(Book book, CancellationToken cancellationToken);

    Task UpdateAsync(Book book, CancellationToken cancellationToken);

    Task DeleteAsync(int id, CancellationToken cancellationToken);

    Task<Book> GetById(int id, CancellationToken cancellationToken);

    Task<Book> GetByFilter(string title, string publisher, CancellationToken cancellationToken);

    Task<List<Book>> GetAll(CancellationToken cancellationToken);
}