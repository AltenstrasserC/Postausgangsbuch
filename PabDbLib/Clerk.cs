using System.Collections.Generic;

namespace PabDbLib
{
    public class Clerk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual List<Packet> Packets { get; set; }
    }
}