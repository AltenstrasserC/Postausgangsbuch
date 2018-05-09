using PabDbLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FilterLib
{
    public class FilterModel : ObservableObject
    {
        #region Variables
        private PabDBContext database;

        public Clerk Clerk { get; set; } = new Clerk(); //Initialize User
        public Person NewPerson { get; set; } = new Person { Adress = new Adress { City = new City() } }; //Initialize New Person

        public Filter NewFilter { get; set; } = new Filter(); //Initialize New Filter

        public Packet NewPacket { get; set; } = new Packet(); //Initialize New Filter

        public List<Filter> Filters { get; set; }

        public List<Person> Senders { get; set; }
        public List<Person> People { get; set; }
        public List<Person> Receivers { get; set; }
        public List<string> SentFromZIP { get; set; }
        public List<string> SentToZIP { get; set; }
        public List<string> Typs { get; set; }
        public int PacketCount { get; set; }
        #endregion

        public int emailCount { get; set; } = 0;
        public int briefCount { get; set; } = 0;
        public int rsaCount { get; set; } = 0;
        public int rsbCount { get; set; } = 0;

        public FilterModel() => database = new PabDBContext();
        public FilterModel(PabDBContext db)
        {
            database = db;
            RefillPacketList();
            Typs = InitTypList();
            Senders = InitSenderList();            

            Receivers = InitReceiverList();
            People = db.Persons.ToList();
            SentFromZIP = InitSenderZIPList();
            SentToZIP = InitReceiverZIPList();
            Filters = InitFilterList();
        }

        

        private string filepath;

        public string Filepath
        {
            get { return filepath; }
            set
            {
                filepath = value;
                NewPacket.FilePath = Filepath;
            }
        }
        public void RefillPacketList()
        {
            Packets = database.Packets.ToList().AsObservableCollection();
            RaisePropertyChangedEvent(nameof(Packets));
        }
        private DateTime deliveryDate;

        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set
            {
                deliveryDate = DateTime.Now;
                deliveryDate = value;
                NewPacket.DeliveryDate = DeliveryDate;
            }
        }
        private ObservableCollection<Packet> packets;
        public ObservableCollection<Packet> Packets
        {
            get { return packets; }
            set
            {
                packets = value;
                PacketCount = Packets.Count();
                RaisePropertyChangedEvent(nameof(PacketCount));
                RaisePropertyChangedEvent(nameof(Packets));
                emailCount = Packets.Count(x => x.Typ.Equals("Email"));
                briefCount = Packets.Count(x => x.Typ.Equals("Brief"));
                rsaCount = Packets.Count(x => x.Typ.Equals("RsA"));
                rsbCount = Packets.Count(x => x.Typ.Equals("RsB"));
            }
        }

        private string ka = "Keine Auswahl";
        private Person kaP = new Person { Name = "Keine Auswahl" };



        private string senderSearchTerm;

        public string SenderSearchTerm
        {
            get { return senderSearchTerm; }
            set
            {
                senderSearchTerm = value;
                if (SenderSearchTerm == "")
                {
                    People = database.Persons.ToList();
                }
                else
                {
                    People = database.Persons.Where(x => x.Name.StartsWith(SenderSearchTerm.ToLower())).ToList();
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
                    People = database.Persons.ToList();
                }
                else
                {
                    People = database.Persons.Where(x => x.Name.StartsWith(ReceiverSearchTerm.ToLower())).ToList();
                }
                RaisePropertyChangedEvent(nameof(People));
            }
        }


        //TODO Filter already Filtered List more efficiently
        public ObservableCollection<Packet> FilterOnCollection()
        {
            ObservableCollection<Packet> filteredCollection = database.Packets.ToList().AsObservableCollection();

            if (MinDate != null)
            {
                filteredCollection = filteredCollection
                .Where(x => x.DeliveryDate >= MinDate).ToList()
                .AsObservableCollection();
            }
            if (MaxDate != null)
            {
                filteredCollection = filteredCollection
                .Where(x => x.DeliveryDate <= MaxDate).ToList()
                .AsObservableCollection();
            }
            if (SelectedSender != null)
            {
                if (SelectedSender != kaP)
                {
                    filteredCollection = filteredCollection
                    .Where(x => x.Sender == SelectedSender).ToList()
                    .AsObservableCollection();
                }
                else
                {
                    SelectedSender = null;
                }

            }
            if (SelectedReceiver != null)
            {
                if (SelectedReceiver != kaP)
                {
                    filteredCollection = filteredCollection
                    .Where(x => x.Receiver == SelectedReceiver).ToList()
                    .AsObservableCollection();
                }
                else
                {
                    SelectedReceiver = null;
                }
            }
            if (Typ != null)
            {
                if (Typ != ka)
                {
                    filteredCollection = filteredCollection
                    .Where(x => x.Typ == Typ).ToList()
                    .AsObservableCollection();
                }
                else
                {
                    Typ = null;
                }
            }
            if (SelectedSentFromZIP != null)
            {
                if (SelectedSentFromZIP != ka)
                {
                    filteredCollection = filteredCollection
                    .Where(x => x.Sender.Adress.City.PostCode == SelectedSentFromZIP).ToList()
                    .AsObservableCollection();
                }
                else
                {
                    Typ = null;
                }
            }
            if (SelectedSentToZIP != null)
            {
                if (SelectedSentToZIP != ka)
                {
                    filteredCollection = filteredCollection
                    .Where(x => x.Receiver.Adress.City.PostCode == SelectedSentToZIP).ToList()
                    .AsObservableCollection();
                }
                else
                {
                    Typ = null;
                }
            }
            return filteredCollection;
        }

        #region Properties
        public Packet SelectedPacket { get; set; }

        private string filternname;
        public string Filtername
        {
            get { return filternname; }
            set
            {
                filternname = value;
                NewFilter.Name = Filtername;
            }
        }

        private Person selectedSender;
        public Person SelectedSender
        {
            get { return selectedSender; }
            set
            {
                selectedSender = value;
                if (selectedSender == null)
                {
                    Packets = Packets.Where(x => x.Sender == SelectedSender).ToList().AsObservableCollection();
                    RaisePropertyChangedEvent(nameof(SelectedSender));
                }
                else
                {
                    Packets = FilterOnCollection();
                    PacketCount = Packets.Count();
                    RaisePropertyChangedEvent(nameof(SelectedSender));
                }
                NewPacket.Sender = SelectedSender;
                NewFilter.Sender = SelectedSender;
            }
        }

        private Person selectedReceiver;
        public Person SelectedReceiver
        {
            get { return selectedReceiver; }
            set
            {
                if (selectedReceiver == null)
                {
                    selectedReceiver = value;
                    Packets = Packets.Where(x => x.Receiver == SelectedReceiver).ToList().AsObservableCollection();
                    RaisePropertyChangedEvent(nameof(SelectedReceiver));
                }
                else
                {
                    selectedReceiver = value;
                    Packets = FilterOnCollection();
                    RaisePropertyChangedEvent(nameof(SelectedReceiver));
                }
                NewPacket.Receiver = SelectedReceiver;
                NewFilter.Receiver = SelectedReceiver;
            }
        }

        private DateTime minDate;
        public DateTime MinDate
        {
            get { return minDate; }
            set
            {
                minDate = value;
                NewFilter.MinDate = MinDate;
                Packets = Packets.Where(x => x.DeliveryDate >= MinDate).ToList().AsObservableCollection();
                RaisePropertyChangedEvent(nameof(Packets));
                RaisePropertyChangedEvent(nameof(MinDate));
            }
        }

        private DateTime maxDate;
        public DateTime MaxDate
        {
            get { return maxDate; }
            set
            {
                maxDate = value;
                NewFilter.MaxDate = MaxDate;
                Packets = Packets.Where(x => x.DeliveryDate <= MaxDate).ToList().AsObservableCollection();//Packets = null
                RaisePropertyChangedEvent(nameof(Packets));
                RaisePropertyChangedEvent(nameof(MaxDate));
            }
        }

        private string typ;
        public string Typ
        {
            get { return typ; }
            set
            {
                if (typ == null)
                {
                    typ = value;
                    Packets = Packets.Where(x => x.Typ == Typ).ToList().AsObservableCollection();
                    RaisePropertyChangedEvent(nameof(Typ));
                }
                else
                {
                    typ = value;
                    Packets = FilterOnCollection();
                    RaisePropertyChangedEvent(nameof(Typ));
                }
                NewPacket.Typ = Typ;
                NewFilter.Typ = Typ;
            }
        }

        private string selectedSentFromZIP;
        public string SelectedSentFromZIP
        {
            get { return selectedSentFromZIP; }
            set
            {
                if (selectedSentFromZIP == null)
                {
                    selectedSentFromZIP = value;
                    Packets = Packets.Where(x => x.Sender.Adress.City.PostCode == SelectedSentFromZIP).ToList().AsObservableCollection();
                    RaisePropertyChangedEvent(nameof(SelectedSentFromZIP));
                }
                else
                {
                    selectedSentFromZIP = value;
                    Packets = FilterOnCollection();
                    RaisePropertyChangedEvent(nameof(SelectedSentFromZIP));
                }
                NewFilter.SenderZIP = SelectedSentFromZIP;
            }
        }

        private string selectedSentToZIP;
        

        public string SelectedSentToZIP
        {
            get { return selectedSentToZIP; }
            set
            {
                if (selectedSentToZIP == null)
                {
                    selectedSentToZIP = value;
                    Packets = Packets.Where(x => x.Receiver.Adress.City.PostCode == SelectedSentToZIP).ToList().AsObservableCollection();
                    RaisePropertyChangedEvent(nameof(SelectedSentToZIP));
                }
                else
                {
                    selectedSentToZIP = value;
                    Packets = FilterOnCollection();
                    RaisePropertyChangedEvent(nameof(SelectedSentToZIP));
                }
                NewFilter.ReceiverZIP = SelectedSentToZIP;
            }
        }
        #endregion
        #region InitLists
        private List<Person> InitSenderList()
        {
            var senderList = new List<Person>();
            var dbSenders = Packets
                .Select(x => x.Sender)
                .Distinct()
                .ToList();
            senderList.Add(kaP);
            foreach (var item in dbSenders)
            {
                senderList.Add(item);
            }
            return senderList;
        }
        private List<string> InitSenderZIPList()
        {
            var zipList = new List<string>();
            var dbSenders = database.Cities
                .Select(x => x.PostCode)
                .ToList();
            zipList.Add("Keine Auswahl");
            foreach (var item in dbSenders)
            {
                zipList.Add(item);
            }
            return zipList;
        }
        private List<string> InitReceiverZIPList()
        {
            var zipList = new List<string>();
            var dbReceivers = database.Cities
                .Select(x => x.PostCode)
                .ToList();
            zipList.Add("Keine Auswahl");
            foreach (var item in dbReceivers)
            {
                zipList.Add(item);
            }
            return zipList;
        }
        private List<Person> InitReceiverList()
        {
            var receiverList = new List<Person>();
            var dbReceivers = Packets
                .Select(x => x.Receiver)
                .Distinct()
                .ToList();
            receiverList.Add(kaP);
            foreach (var item in dbReceivers)
            {
                receiverList.Add(item);
            }
            return receiverList;
        }

        private List<Person> InitPersonList()
        {
            var personList = new List<Person>();
            var dbPersons = database.Persons.Distinct().ToList();
            personList.Add(kaP);
            foreach (var item in dbPersons)
            {
                personList.Add(item);
            }
            return personList;
        }

        private List<string> InitTypList()
        {
            var typlist = new List<string>();
            typlist.Add("Keine Auswahl");
            typlist.Add("Brief");
            typlist.Add("Email");
            typlist.Add("RsA");
            typlist.Add("RsB");
            return typlist;
        }

        private List<Filter> InitFilterList()
        {
            var filterList = new List<Filter>();
            var dbFilters = database.Filters.ToList();
            foreach (var item in dbFilters)
            {
                filterList.Add(item);
            }
            return filterList;
        }
        #endregion
        #region Commands
        public ICommand CreatePacket => new RelayCommand<string>(
            DoCreatePacket,
            x => true
            );

        private void DoCreatePacket(string obj)
        {
            database.Database.Log = Console.WriteLine;
            MessageBox.Show($"Packet added!");
            database.Packets.Add(NewPacket);
            NewPacket = new Packet { Clerk = Clerk };
            database.SaveChanges();
            RaisePropertyChangedEvent(nameof(Packets));
        }
        public ICommand ResetFilter => new RelayCommand<string>(
            DoResetFilter,
            x => true
            );

        private void DoResetFilter(string obj)
        {
            NewFilter = new Filter();
        }

        public ICommand CreateNewPerson => new RelayCommand<string>(
            DoCreateNewPerson,
            x => true
            );

        private void DoCreateNewPerson(string obj)
        {
            var personAdresss = NewPerson.Adress;
            if (database.Cities.Count(x => x.PostCode.Equals(personAdresss.City.PostCode)) != 0)
            {
                var id = database.Cities.First(x => x.PostCode.Equals(personAdresss.City.PostCode));
                personAdresss.City = id;

            }
            NewPerson.Adress.City.Country = "Austria";
            database.Database.Log = Console.WriteLine;
            MessageBox.Show($"Person {NewPerson.Name} added!");
            database.Persons.Add(NewPerson);
            NewPerson = new Person { Adress = new Adress { City = new City() } };
            database.SaveChanges();

            Senders = InitSenderList();
            Receivers = InitReceiverList();
            People = database.Persons.ToList();
            RaisePropertyChangedEvent(nameof(People));
            RaisePropertyChangedEvent(nameof(Senders));
            RaisePropertyChangedEvent(nameof(Receivers));
        }
        public ICommand CreateFilter => new RelayCommand<string>(
            DoCreateFilter,
            x => true
            );

        private void DoCreateFilter(string obj)
        {
            database.Database.Log = Console.WriteLine;
            NewFilter.Clerk = Clerk;
            MessageBox.Show($"Filter {NewFilter.Name} added!");
            database.Filters.Add(NewFilter);
            NewFilter = new Filter();
            database.SaveChanges();
            RaisePropertyChangedEvent(nameof(Filters));

        }
        #endregion
    }
}
