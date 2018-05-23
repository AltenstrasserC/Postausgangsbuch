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
    public class FilterAttributesModel : ObservableObject
    {
        private PabDBContext db;
        #region FormInformation
        public List<Person> Senders { get; set; }
        public List<Person> Receivers { get; set; }
        public List<string> SenderPostcodes { get; set; }
        public List<string> ReceiverPostcodes { get; set; }
        public int PacketCount { get; set; }
        #endregion
        #region privateVariables
        private string filtername;
        private bool briefChecked;
        private bool emailChecked;
        private bool rsaChecked;
        private bool rsbChecked;
        private ObservableCollection<Packet> packets;
        private DateTime startDate;
        private DateTime endDate;
        private Person sender;
        private Person receiver;
        private string senderPostcode;
        private string receiverPostcode;
        #endregion
        #region PublicVariables
        
        public string Filtername
        {
            get { return filtername; }
            set {
                filtername = value;
                RaisePropertyChangedEvent(nameof(Filtername));
            }
        }

        public Clerk Clerk { get; set; }
        public bool BriefChecked
        {
            get { return briefChecked; }
            set
            {
                briefChecked = value;
                RaisePropertyChangedEvent(nameof(BriefChecked));
                FilterOnCollection();
            }
        }
        public bool EmailChecked
        {
            get { return emailChecked; }
            set
            {
                emailChecked = value;
                RaisePropertyChangedEvent(nameof(EmailChecked));
                FilterOnCollection();
            }
        }
        public bool RsaChecked
        {
            get { return rsaChecked; }
            set
            {
                rsaChecked = value;
                RaisePropertyChangedEvent(nameof(RsaChecked));
                FilterOnCollection();
            }
        }
        public bool RsbChecked
        {
            get { return rsbChecked; }
            set
            {
                rsbChecked = value;
                RaisePropertyChangedEvent(nameof(RsbChecked));
                FilterOnCollection();
            }
        }
        
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                RaisePropertyChangedEvent(nameof(StartDate));
                FilterOnCollection();
            }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                RaisePropertyChangedEvent(nameof(EndDate));
                FilterOnCollection();
            }
        }
        public Person Sender
        {
            get { return sender; }
            set
            {
                sender = value;
                RaisePropertyChangedEvent(nameof(Sender));
                FilterOnCollection();
            }
        }
        public Person Receiver
        {
            get { return receiver; }
            set
            {
                receiver = value;
                RaisePropertyChangedEvent(nameof(Receiver));
                FilterOnCollection();
            }
        }
        public string SenderPostcode
        {
            get { return senderPostcode; }
            set
            {
                senderPostcode = value;
                RaisePropertyChangedEvent(nameof(SenderPostcode));
                FilterOnCollection();
            }
        }
        public string ReceiverPostcode
        {
            get { return receiverPostcode; }
            set
            {
                receiverPostcode = value;
                RaisePropertyChangedEvent(nameof(ReceiverPostcode));
                FilterOnCollection();
            }
        }

        public int emailCount { get; set; } = 0;
        public int briefCount { get; set; } = 0;
        public int rsaCount { get; set; } = 0;
        public int rsbCount { get; set; } = 0;

        public string SelectedYear { get; set; }
        public bool[] SelectedMonths { get; set; } = { false, false, false, false, false, false, false, false, false, false, false, false };
        public bool[] Months { get; set; } = { false, false, false, false, false, false, false, false, false, false, false, false };
        public string HoverTyp { get; set; }

        public ObservableCollection<Packet> Packets
        {
            get { return packets; }
            set
            {
                packets = value;
                PacketCount = Packets.Count;
                RaisePropertyChangedEvent(nameof(PacketCount));
                RaisePropertyChangedEvent(nameof(Packets));

                try
                {
                    emailCount = Packets.Count(x => x.Typ.Equals("Email"));
                    briefCount = Packets.Count(x => x.Typ.Equals("Brief"));
                    rsaCount = Packets.Count(x => x.Typ.Equals("RsA"));
                    rsbCount = Packets.Count(x => x.Typ.Equals("RsB"));
                }
                catch (Exception exc)
                {
                    //Shows Messagebox: Error!
                    MessageBox.Show($"Error: {exc.Message}");
                }
                
            }
        }
        #endregion

        public FilterAttributesModel() { }
        public FilterAttributesModel(PabDBContext db, Clerk clerk)
        {
            this.db = db;
            this.Clerk = clerk;
            LoadFilterAttributesModel();
        }

        public void LoadFilterAttributesModel()
        {
            Packets = db.Packets.ToList().AsObservableCollection();
            PacketCount = Packets.Count;
            Filtername = null;

            EmailChecked = false;
            BriefChecked = false;
            RsaChecked = false;
            RsbChecked = false;

            StartDate = DateTime.Parse("01.01.1990");
            EndDate = DateTime.Now;

            Sender = null;
            Receiver = null;

            SenderPostcode = null;
            ReceiverPostcode = null;

            Senders = db.Persons.ToList();
            Receivers = db.Persons.ToList();
            SenderPostcodes = db.Cities.Select(x => x.ZIP).ToList();
            ReceiverPostcodes = db.Cities.Select(x => x.ZIP).ToList();

            HoverTyp = null;
            SelectedYear = null;
            SelectedMonths = Months;

            FilterOnCollection();
        }

        public ICommand CreateFilter => new RelayCommand<string>(
            DoCreateFilter,
            x => true
            );
        private void DoCreateFilter(string obj)
        {
            try
            {
                //Creates new Filterobject
                Filter newFilter = new Filter();
                newFilter.Clerk = Clerk;
                newFilter.FilterName = Filtername;
                newFilter.isLetter = BriefChecked;
                newFilter.isEmail = EmailChecked;
                newFilter.isRsA = RsaChecked;
                newFilter.isRsB = RsbChecked;
                newFilter.MinDate = StartDate;
                newFilter.MaxDate = EndDate;
                newFilter.Sender = Sender;
                newFilter.Receiver = Receiver;
                newFilter.SenderZIP = SenderPostcode;
                newFilter.ReceiverZIP = ReceiverPostcode;

                //Saves Filterobject in database
                db.Filters.Add(newFilter);
                db.SaveChanges();

                //Shows Messagebox: Success!
                LoadFilterAttributesModel();
                MessageBox.Show($"Filter {Filtername} added!");
                RaisePropertyChangedEvent(nameof(OverviewModel.Filters));
            }
            catch (Exception e)
            {
                //Shows Messagebox: Error!
                MessageBox.Show($"Filter {Filtername} not added: {e.Message}");
            }

        }
        private void FilterOnCollection()
        {
            var p = db.Packets.Select(x => x).ToList();
            if (StartDate != null)
            {
                p = p.Where(x => x.DeliveryDate >= StartDate).ToList();
            }
            if (EndDate != null)
            {
                p = p.Where(x => x.DeliveryDate <= EndDate).ToList();
            }
            if (Sender != null)
            {
                p = p.Where(x => x.Sender == Sender).ToList();
            }
            if (Receiver != null)
            {
                p = p.Where(x => x.Receiver == Receiver).ToList();
            }
            if (SenderPostcode != null)
            {
                p = p.Where(x => x.Sender.Adress.City.ZIP == SenderPostcode).ToList();
            }
            if (ReceiverPostcode != null)
            {
                p = p.Where(x => x.Receiver.Adress.City.ZIP == ReceiverPostcode).ToList();
            }
            if (BriefChecked == true)
            {
                p = p.Where(x => x.Typ == "Brief").ToList();
            }
            if (EmailChecked == true)
            {
                p = p.Where(x => x.Typ == "Email").ToList();
            }
            if (RsaChecked == true)
            {
                p = p.Where(x => x.Typ == "RsA").ToList();
            }
            if (RsaChecked == true)
            {
                p = p.Where(x => x.Typ == "RsB").ToList();
            }
            Packets = p.AsObservableCollection();
        }
        public ObservableCollection<Packet> FilterOnStatistik()
        {
            ObservableCollection<Packet> filteredCollection = db.Packets.ToList().AsObservableCollection();
            if (SelectedYear != "" && SelectedYear != null)
            {
                filteredCollection = filteredCollection
                        .Where(x => x.DeliveryDate.Value.Year.ToString() == SelectedYear)
                        .ToList()
                        .AsObservableCollection();
            }
            var count = 0;
            foreach (var value in SelectedMonths)
            {
                if (value == true)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                for (int i = 1; i <= 12; i++)
                {
                    filteredCollection = filteredCollection
                        .Where(x => SelectedMonths[int.Parse(x.DeliveryDate.Value.Month.ToString()) - 1])
                        .ToList()
                        .AsObservableCollection();
                }
            }
            if (HoverTyp != null)
            {
                filteredCollection = filteredCollection
                        .Where(x => x.Typ == HoverTyp)
                        .ToList()
                        .AsObservableCollection();
            }
            return filteredCollection;
        }
    }

}
