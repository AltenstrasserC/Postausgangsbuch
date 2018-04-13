using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PabDbLib
{
    public class City
    {
        public int Id { get; set; }
        public string PostCode { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual List<Adress> Adresses { get; set; } = new List<Adress>();
    }
}
