using System;
using System.Collections.Generic;

#nullable disable

namespace covidpassbackend.Models
{
    public partial class Test
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public bool? Result { get; set; }
        public DateTime? DateOfTest { get; set; }

        public virtual User User { get; set; }
    }
}
