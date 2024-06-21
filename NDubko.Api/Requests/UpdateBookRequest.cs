using System.ComponentModel.DataAnnotations;

namespace NDubko.Api.Requests;

public class UpdateBookRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Title { get; set; }

    [Required]
    [MinLength(3)]
    public string Publisher { get; set; }
}
