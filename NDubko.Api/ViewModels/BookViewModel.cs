namespace NDubko.Api.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Publisher { get; set; }

    public AuthorDetailsViewModel Author { get; set; }
}