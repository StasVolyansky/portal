using Portal.Domain.Common;

namespace Portal.Domain.System
{
    public class RoleEnrolment : Entity
    {
        public int RoleId { get; set; }

        public RoleEnrolment(int roleId)
        {
            RoleId = roleId;
        }
    }
}