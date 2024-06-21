using System.ComponentModel.DataAnnotations;

namespace NDubko.Api.Requests;

public class UpdateAuthorRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(3)]
    public string LastName { get; set; }
}