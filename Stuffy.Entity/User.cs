using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Stuffy.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int ColourCode
        {
            get
            {
                return Colour.ToArgb();
            }
            set
            {
                Colour = Color.FromArgb(value);
            }
        }

        [NotMapped]
        private Color Colour { get; set; }

        public User()
        {
            Id = 0;
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
