using System.ComponentModel.DataAnnotations;

namespace NDubko.Api.Requests;

public class CreateBookRequest
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; }

    [Required]
    [MinLength(3)]
    public string Publisher { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
    public int AuthorId { get; set; }
}
