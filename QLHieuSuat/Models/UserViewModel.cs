using Microsoft.AspNetCore.Identity;

namespace QLHieuSuat.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public List<IdentityRole> AllRoles { get; set; }
    }
}