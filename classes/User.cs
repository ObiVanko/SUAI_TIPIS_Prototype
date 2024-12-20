
namespace Prototype
{
    public class User
    {
        internal Artist Artist;
        internal Platform Platform;

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public string Email { get; set; }
    }
}
