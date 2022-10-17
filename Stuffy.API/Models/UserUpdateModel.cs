using Stuffy.Entity;

namespace Stuffy.API.Models
{
    public class UserUpdateModel : UserViewModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public UserUpdateModel() : base() { }

        public UserUpdateModel(User user) : base(user) { }

        public override User ToEntity()
        {
            return new User
            {
                Id = Id,
                Username = Username,
                Email = Email,
                Password = NewPassword,
            };
        }
    }
}
