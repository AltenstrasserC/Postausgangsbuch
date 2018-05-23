using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PabDbLib
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool isCompany { get; set; }
        public virtual List<Packet> PacketsSent { get; set; } = new List<Packet>();
        public virtual List<Packet> PacketsReceived { get; set; } = new List<Packet>();
        public virtual Adress Adress { get; set; }
        [NotMapped]
        public string Name => $"{LastName} {FirstName}";
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}