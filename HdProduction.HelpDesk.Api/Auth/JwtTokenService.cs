using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using HdProduction.App.Common.Auth;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace HdProduction.HelpDesk.Api.Auth
{
  public class JwtTokenService : ITokenService
  {
    private readonly JsonWebKey _privateSecret;

    public JwtTokenService(string privateKeyPath)
    {
      _privateSecret = JsonWebKey.Create(ReadFile(privateKeyPath));
    }

    public string CreateToken(User user)
    {
      // authentication successful so generate jwt token
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
          new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
          new Claim(JwtRegisteredClaimNames.Email, user.Email),
          new Claim(JwtDefaults.ClaimsRoleType, user.PermissionsRaw), 
          new Claim(JwtDefaults.ProjectId, user.ProjectId.ToString()), 
        }),
        Expires = DateTime.UtcNow.AddMinutes(30),
        Issuer = JwtDefaults.Issuer,
        SigningCredentials = new SigningCredentials(_privateSecret, SecurityAlgorithms.RsaSha256Signature)
      };
      var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    private string ReadFile(string path)
    {
      using (var stream = File.OpenText(path))
      {
        return stream.ReadToEnd();
      }
    }
  }
}