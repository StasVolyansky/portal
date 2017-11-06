using Portal.Domain.Common;
using System.Collections.Generic;

namespace Portal.Domain.System
{
    public class User : Entity
    {
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }

        private List<Role> roles = new List<Role>();
        public IEnumerable<Role> Roles => roles;

        public User(string userName, string passwordHash, string email)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }
    }
}