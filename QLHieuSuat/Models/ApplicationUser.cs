using Microsoft.AspNetCore.Identity;

namespace QLHieuSuat.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}