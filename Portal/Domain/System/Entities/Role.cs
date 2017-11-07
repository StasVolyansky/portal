using Portal.Domain.Common;

namespace Portal.Domain.System.Entities
{
    public class Role : Entity
    {
        public string Name { get; private set; }

        public Role(string name)
        {
            Name = name;
        }
    }
}