namespace eudaci.Models
{
    public class Settings
    {
        public int Id { get; set; }

        public bool Notifications { get; set; }

        public bool Sugestions { get; set; }

        public bool NotifyVaccination { get; set; }

        public bool NotifyPandemic { get; set; }

        public ApplicationUser User { get; set; }
    }
}
