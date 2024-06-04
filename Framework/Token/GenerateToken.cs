using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Framework.Token
{
    public class GenerateToken:IGenerateNewToken
    {
        private IConfiguration _confiquration;

        public GenerateToken(IConfiguration confiquration)
        {
            _confiquration = confiquration;
        }
        public string GenerateNewToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_confiquration.GetValue<string>("TokenKey"));
            var tokenTimeOut = _confiquration.GetValue<int>("tokenTimeOut");
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new Claim[]
                {
                    new Claim("userGuid",userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(tokenTimeOut),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
