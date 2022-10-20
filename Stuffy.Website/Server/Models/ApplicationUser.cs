using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Stuffy.Website.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
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
    }
}