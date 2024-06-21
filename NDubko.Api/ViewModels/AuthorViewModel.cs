namespace NDubko.Api.ViewModels;

public class AuthorViewModel
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IEnumerable<BookDetailsViewModel> Books { get; set; }
}