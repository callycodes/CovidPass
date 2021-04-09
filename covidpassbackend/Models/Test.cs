using System;
namespace covidpassbackend.Models
{
    public class User
    {
        public long id { get; set; }
        public string uid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }

    }
}
