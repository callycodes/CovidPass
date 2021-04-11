using System;
using System.Collections.Generic;

#nullable disable

namespace covidpassbackend.Models
{
    public partial class Vaccine
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public int? Count { get; set; }
        public DateTime? DateOfVaccine { get; set; }

        public virtual User User { get; set; }
    }
}
