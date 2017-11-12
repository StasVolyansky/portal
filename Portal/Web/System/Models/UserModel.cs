using Portal.Web.Data.Attributes;

namespace Portal.Web.System.Models
{
    [DataSource("Users")]
    public class UserModel
    {
        public string Email { get; set; }
    }
}