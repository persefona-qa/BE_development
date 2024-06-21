using NDubko.Domain;

namespace NDubko.Database.Repositories;
public interface IAuthorRepository
{
    Task<int> CreateAsync(Author author, CancellationToken cancellationToken);

    Task UpdateAsync(Author author, CancellationToken cancellationToken);

    Task DeleteAsync(int id, CancellationToken cancellationToken);

    Task<Author> GetById(int id, CancellationToken cancellationToken);

    Task<Author> GetByFilter(string firstName, string lastName, CancellationToken cancellationToken);

    Task<List<Author>> GetAll(CancellationToken cancellationToken);
}