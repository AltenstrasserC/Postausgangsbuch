using PabDbLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLib
{
    public class SearchModel : ObservableObject
    {
        private PabDBContext db;
        
        
        private ObservableCollection<Packet> packets;
        public ObservableCollection<Packet> Packets
        {
            get { return packets; }
            set
            {
                packets = value;
                RaisePropertyChangedEvent(nameof(Packets));
            }
        }
        
        public Clerk Clerk { get; set; }
        public Packet SelectedPacket { get; set; }

        public SearchModel() { }
        public SearchModel(PabDBContext db, Clerk clerk)
        {
            this.db = db;
            this.Clerk = clerk;
            LoadSearchModel();
        }

        public void LoadSearchModel()
        {
            Packets = db.Packets.ToList().AsObservableCollection();
            
        }
        
    }
}
