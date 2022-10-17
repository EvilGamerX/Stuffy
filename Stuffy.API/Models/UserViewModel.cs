using Stuffy.Entity;

namespace Stuffy.API.Models
{
    public class UserViewModel : IViewModel<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public UserViewModel() { }

        public UserViewModel(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
        }

        public virtual User ToEntity()
        {
            return new User
            {
                Id = Id,
                Username = Username,
                Email = Email,
                Password = null
            };
        }
    }
}
