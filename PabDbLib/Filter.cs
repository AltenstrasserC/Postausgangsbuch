using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PabDbLib
{
    public class Filter
    {
        public int Id { get; set; }
        public string FilterName { get; set; }
        public virtual Person Sender { get; set; }
        public virtual Person Receiver { get; set; }
        public bool isLetter { get; set; } = false;
        public bool isEmail { get; set; } = false;
        public bool isRsA { get; set; } = false;
        public bool isRsB { get; set; } = false;
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string SenderZIP { get; set; }
        public string ReceiverZIP { get; set; }
        public virtual Clerk Clerk { get; set; }
        
        
}
}
