using System;

namespace eudaci.API {
    public class VaccinationData
    {
        public string location { get; set; }
        public string date { get; set; }
        public string vaccine { get; set; }
        public string source_url { get; set; }
        public string total_vaccinations { get; set; }
        public string people_vaccinated { get; set; }
        public string people_fully_vaccinated { get; set; }
    }
}
