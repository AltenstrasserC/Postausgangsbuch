using PabDbLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace FilterLib
{
    public class OverviewModel : ObservableObject
    {
        public PabDBContext database;
        public Clerk Clerk { get; set; } = new Clerk();
        public List<Filter> Filters { get; set; }
        public OverviewModel() => database = new PabDBContext();
        public OverviewModel(PabDBContext db)
        {
            database = db;
            Filters = db.Filters.ToList();
        }
    }
}
