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
        private ObservableCollection<Filter> filters;

        public ObservableCollection<Filter> Filters
        {
            get { return filters; }
            set {
                filters = value;
                RaisePropertyChangedEvent(nameof(Filters));
            }
        }
        
        public OverviewModel() => database = new PabDBContext();
        public OverviewModel(PabDBContext db)
        {
            database = db;
            Filters = db.Filters.ToList().AsObservableCollection();
        }
    }
}
