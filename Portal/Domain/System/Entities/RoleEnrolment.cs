using Portal.Domain.Common;

namespace Portal.Domain.System.Entities
{
    public class RoleEnrolment : Entity
    {
        public Role Role { get; set; }

        public RoleEnrolment(Role role)
        {
            Role = role;
        }
    }
}