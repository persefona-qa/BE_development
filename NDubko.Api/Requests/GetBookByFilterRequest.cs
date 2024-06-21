namespace NDubko.Api.Requests;

public class GetBookByFilterRequest
{
    public string Title { get; set; } = string.Empty;

    public string Publisher { get; set; } = string.Empty;
}