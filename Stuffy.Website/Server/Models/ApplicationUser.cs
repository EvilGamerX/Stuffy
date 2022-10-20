using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Stuffy.Website.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ColourCode { get; set; }
    }
}