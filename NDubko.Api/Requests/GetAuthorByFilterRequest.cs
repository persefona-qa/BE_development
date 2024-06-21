namespace NDubko.Api.Requests;

public class GetAuthorByFilterRequest
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}