

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Authentication;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Harpoon;

public class IdentityService
{
    public string Authenticate(string email, string password)
    {
        //Your custom logic here (e.g. database query)
        //Mocked for a sake of simplicity
        var roles = new List<string>();

        if (email == "krisys@gmail.com"
            && password == "k1l0m3tr3$")
        {
            roles.Add("administrator");
        }

        if (roles.Count > 0)
        {
            // TODO: This token is not authenticating when used in Authorization header
            return this.GenerateAccessToken(email, Guid.NewGuid().ToString(), roles.ToArray());
        }

        throw new AuthenticationException("Invalid credentials");
    }

    private string GenerateAccessToken(string email, string userId, string[] roles)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("B3atiful$undayMorning"));

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, email)
        };

        claims = claims.Concat(roles.Select(role => new Claim(ClaimTypes.Role, role))).ToList();

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            "https://localhost:5001/",
            "www",
            claims,
            expires: DateTime.Now.AddDays(90),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}