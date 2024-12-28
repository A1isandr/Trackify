using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Trackify.Helpers;

public static class AuthOptions
{
    public const string Issuer = "TrackifyServer";
    public const string Audience = "TrackifyClient";
    
    private const string Key = "onedayiwillreachouttoyouandyouwillneverknowwhatimeanbythatsokeepbelivinginfuture";
    
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new (Encoding.UTF8.GetBytes(Key));
}