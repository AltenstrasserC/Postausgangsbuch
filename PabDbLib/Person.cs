using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PabDbLib
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Business { get; set; }
        public virtual List<Packet> PacketsSent { get; set; } = new List<Packet>();
        public virtual List<Packet> PacketsReceived { get; set; } = new List<Packet>();
        public virtual Adress Adress { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}