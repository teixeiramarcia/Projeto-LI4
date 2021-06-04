using System.Collections.Generic;

namespace eudaci.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public string GeographicLocation { get; set; }

        public List<Vaccination> Vaccinations { get; set; }

        public List<Pandemic> Pandemics { get; set; }
    }
}
