using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace WorkWaveApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public int UserRoleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public UserRole UserRole { get; set; }


        public void AddPassword(string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor: 13);

            Password = passwordHash;
        }

        public bool VerifyPassword(string password)
        {
            var verifyPassword = BCrypt.Net.BCrypt.EnhancedVerify(password, Password);

            return verifyPassword;
        }

    }
}
