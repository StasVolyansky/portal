namespace Portal.Domain.System
{
    public class SystemService
    {
        public User CreateUser(string email, string password)
        {
            return new User(email, HashPassword(password));
        }

        public string HashPassword(string password) =>
            password.GetHashCode().ToString();
    }
}