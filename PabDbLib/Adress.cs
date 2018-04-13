using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PabDbLib

{
    public class Adress
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNr { get; set; }
        public virtual City City { get; set; }
        public virtual List<Person> Persons { get; set; } = new List<Person>();
    }
}