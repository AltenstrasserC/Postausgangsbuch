using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PabDbLib
{
    public class PabDBContext : DbContext
    {
        public PabDBContext() : base("PabDb")
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }
        public DbSet<Packet> Packets { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Clerk> Clerks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Filter> Filters { get; set; }
    }
}
