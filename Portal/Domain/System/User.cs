using Portal.Domain.Common;

namespace Portal.Domain.System
{
    public class User : Entity
    {
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }

        public User(string userName, string passwordHash, string email)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }
    }
}