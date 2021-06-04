using System;
using System.ComponentModel.DataAnnotations;

namespace eudaci.Models
{
    public class Vaccination
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int QuantityFirstDose { get; set; }

        public int QuantitySecondDose { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
