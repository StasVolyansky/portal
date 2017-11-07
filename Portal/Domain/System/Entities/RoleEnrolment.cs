using Portal.Domain.Common;
using System.Collections.Generic;

namespace Portal.Domain.System.Entities
{
    public class RoleEnrolment : Entity
    {
        public List<User> users = new List<User>();
        public IEnumerable<User> Users => users;

        public List<Role> roles = new List<Role>();
        //public IEnumerable<User> Roles => roles;

        protected RoleEnrolment() { }

        //public void AddUser(User user)
        //{
        //    users
        //}
    }
}