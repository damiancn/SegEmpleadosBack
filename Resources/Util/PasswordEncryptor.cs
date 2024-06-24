namespace DataAcccess.Util
{
    using Dtos.Common;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordEncryptor
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Iterations = 1000;
        public static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool PasswordVerification(string password, string hashedPassword)
        {
            var hashBytes = Convert.FromBase64String(hashedPassword);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static JwtSecurityToken CreateToken(TokenUtil model)
        {
            string validIssuer = model.Issuer;
            string validAudience = model.Audience;
            SymmetricSecurityKey issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(model.Key));

            // La fecha de expiracion sera el mismo dia a las 12 de la noche
            DateTime dtFechaExpiraToken;
            DateTime now = DateTime.Now;
            dtFechaExpiraToken = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 999);

            // Agregamos los claim nuestros
            var claims = new[]
            {
                new Claim("Name", model.Name),
                new Claim("namemail", $"{model.Name}"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), // si es necesario que se desloguee de diferentes dispositivos podemos usar esto
            };

            return new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                claims: claims,
                expires: dtFechaExpiraToken,
                notBefore: now,
                signingCredentials: new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256));
        }
    }
}


