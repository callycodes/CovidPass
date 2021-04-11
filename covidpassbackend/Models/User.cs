using System;
using System.Collections.Generic;

#nullable disable

namespace covidpassbackend.Models
{
    public partial class User
    {
        public User()
        {
            Tests = new HashSet<Test>();
            Vaccines = new HashSet<Vaccine>();
        }

        public int Id { get; set; }
        public string Uid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public ICollection<Test> Tests { get; set; }
        public virtual ICollection<Vaccine> Vaccines { get; set; }
    }

    public partial class UserAuthenticate
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
