using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NDubko.Application.Options;

/// <summary>
/// Task for #8 Configuration
/// </summary>
public class AuthOptions
{
    public string Issuer { get; set; }

    public string Audience { get; set; }

    public string Key { get; set; }

    public SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));
}
