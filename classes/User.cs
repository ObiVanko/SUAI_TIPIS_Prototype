
namespace Prototype
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public string Email { get; set; }

        public Artist Artist { get; set; } 
        public Platform Platform { get; set; }
    }
}
