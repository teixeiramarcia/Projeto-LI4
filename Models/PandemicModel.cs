using System;
using System.ComponentModel.DataAnnotations;

namespace eudaci.Models
{
    public class Pandemic
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int Deaths { get; set; }

        public int Infected { get; set; }

        public int Recovered { get; set; }

        public int Hospitalisations { get; set; }


        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
