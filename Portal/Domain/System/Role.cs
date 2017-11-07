using Portal.Domain.Common;

namespace Portal.Domain.System
{
    public class Role : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Role(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}