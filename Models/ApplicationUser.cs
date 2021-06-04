using Microsoft.AspNetCore.Identity;

namespace eudaci.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? SettingsId { get; set; }
        public Settings Settings { get; set; }
    }
}
