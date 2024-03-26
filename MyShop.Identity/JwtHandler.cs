using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyShop.Domain.AggregateModels.UserAggregate.Models;

namespace MyShop.Identity;

public class JwtHandler
{
    private string _issuer;
    private string _audience;
    private string _privateKey;

    public JwtHandler(string issuer, string audience, string privateKey)
    {
        _issuer = issuer;
        _audience = audience;
        _privateKey = privateKey;
    }

    public string GenerateToken(MyShopUser user)
    {
        var issuer = _issuer;
        var audience = _audience;
        var key = Encoding.ASCII.GetBytes(_privateKey);
        var tokenDescriptor = new SecurityTokenDescriptor 
        { 
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        return jwtToken;
    }
}