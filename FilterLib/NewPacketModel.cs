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
    public class NewPacketModel : ObservableObject
    {
        public PabDBContext db { get; set; }

        public Clerk Clerk { get; set; }
        public Packet Packet { get; set; }
        private ObservableCollection<Person> people;

        public ObservableCollection<Person> People
        {
            get { return people; }
            set {
                people = value;
                RaisePropertyChangedEvent(nameof(People));
            }
        }

        public string[] Typs { get; set; }
        public NewPacketModel()
        {

        }
        public NewPacketModel(PabDBContext db, Clerk clerk)
        {
            this.db = db;
            this.Clerk = clerk;
            LoadNewPacketModel();
        }
        public void LoadNewPacketModel()
        {
            Packet = new Packet();
            Packet.Clerk = Clerk;
            People = db.Persons.ToList().AsObservableCollection();
            Typs = new string[]{ "Brief", "Email","RsA","RsB" };
        }


        public ICommand CreatePacket => new RelayCommand<string>(
            DoCreatePacket,
            x => true
            );

        private void DoCreatePacket(string obj)
        {
            
            MessageBox.Show($"Packet added!");
            db.Packets.Add(Packet);
            db.SaveChanges();

            LoadNewPacketModel();
        }
        private string senderSearchTerm;

        public string SenderSearchTerm
        {
            get { return senderSearchTerm; }
            set
            {
                senderSearchTerm = value;
                if (SenderSearchTerm == "")
                {
                    People = db.Persons.ToList().AsObservableCollection();
                }
                else
                {
                    People = db.Persons.Where(x => x.LastName.StartsWith(SenderSearchTerm.ToLower())).ToList().AsObservableCollection();
                }
                RaisePropertyChangedEvent(nameof(People));
            }
        }
        private string receiverSearchTerm;

        public string ReceiverSearchTerm
        {
            get { return receiverSearchTerm; }
            set
            {
                receiverSearchTerm = value;
                if (ReceiverSearchTerm == "")
                {
                    People = db.Persons.ToList().AsObservableCollection();
                }
                else
                {
                    People = db.Persons.Where(x => x.LastName.StartsWith(ReceiverSearchTerm.ToLower())).ToList().AsObservableCollection();
                }
                RaisePropertyChangedEvent(nameof(People));
            }
        }
    }
}
