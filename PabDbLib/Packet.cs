using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PabDbLib
{
    public class Packet
    {
        public int Id { get; set; }
        public virtual Person Sender { get; set; }
        public virtual Person Receiver { get; set; }
        public string Typ { get; set; }
        public string FilePath { get; set; }
        public virtual Clerk Clerk { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
