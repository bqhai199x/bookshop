using BCrypt.Net;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Auth
{
    public static class AuthExtension
    {
        public static string GenerateJWTToken(Account account)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.SecretKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, account.UserName),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role.ToString())
            };
            var tokeOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(JwtConfig.ExpireTime),
                signingCredentials: signinCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.SecretKey)),
            };
            SecurityToken securityToken;
            var principal = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        public static string GenaratePasswordHash(string rawPassword)
        {
            string hashPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(rawPassword, HashType.SHA512);
            return hashPassword;
        }

        public static bool VerifyPasswordHash(string rawPassword, string hashPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(rawPassword, hashPassword, HashType.SHA512);
        }
    }
}
