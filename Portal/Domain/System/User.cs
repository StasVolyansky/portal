using Portal.Domain.Common;
using System.Collections.Generic;

namespace Portal.Domain.System
{
    public class User : Entity
    {
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        private readonly List<RoleEnrolment> roleEnrolments = new List<RoleEnrolment>();
        public IEnumerable<RoleEnrolment> RoleEnrolments => roleEnrolments;

        public User(string email, string passwordHash)
        {
            PasswordHash = passwordHash;
            Email = email;
        }

        public void Update(string email = default, string passwordHash = default)
        {
            if (email != default)
                Email = email;

            if (passwordHash != default)
                PasswordHash = passwordHash;
        }

        public void AddRoleEnrolment(int roleId)
        {
            roleEnrolments.Add(new RoleEnrolment(roleId));
        }
    }
}