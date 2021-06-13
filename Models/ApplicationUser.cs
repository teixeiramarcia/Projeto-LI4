using Microsoft.AspNetCore.Identity;

namespace eudaci.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public int? SettingsId { get; set; }
        public Settings Settings { get; set; }
    }
}
