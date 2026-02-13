namespace Src.Infra.Adapters;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Src.Core.Ports;

public class AuthAdapter : IAuthPort
{
    public string GenerateAccessToken(string nameFull, string email, long? id)
    {
        var tokenHandler=new JwtSecurityTokenHandler();
        var key= Encoding.ASCII.GetBytes("X2U3askdYMxjL1wRc8Ai8GAXJL901G0TQPSltdCnJqO");
        var tokenDescriptor=new SecurityTokenDescriptor()
        {
            Subject= new ClaimsIdentity(new[]
            {
             new Claim("FullName",nameFull),
             new Claim("Email",email),
             new Claim("Id",id.ToString())   
            }),
            Expires=DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)  
        };
         var token=tokenHandler.CreateToken(tokenDescriptor);
         return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken(string nameFull, string email, long? id)
    {
           var tokenHandler=new JwtSecurityTokenHandler();
        var key= Encoding.ASCII.GetBytes("X2U3askdYMxjL1wRc8Ai8GAXJL901G0TQPSltdCnJqO");
        var tokenDescriptor=new SecurityTokenDescriptor()
        {
            Subject= new ClaimsIdentity(new[]
            {
             new Claim("FullName",nameFull),
             new Claim("Email",email),
             new Claim("Id",id.ToString())   
            }),
            Expires=DateTime.UtcNow.AddHours(12),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)  
        };
         var token=tokenHandler.CreateToken(tokenDescriptor);
         return tokenHandler.WriteToken(token);
    }
}