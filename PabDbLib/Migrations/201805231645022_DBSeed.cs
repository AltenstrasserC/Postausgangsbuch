namespace PabDbLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;

    public partial class DBSeed : DbMigration
    {
        public override void Up()
        {
            using (PabDBContext context = new PabDBContext())
            {
                var clerks = new Clerk[] { new Clerk { Name = "admin" }, new Clerk { Name = "jr", Password = "jr" } };
                context.Clerks.AddOrUpdate(clerks);
                var data = new Person[] {
                new Person{ FirstName = "Beatrice", LastName = "Keith", Email = "Proin.mi@velitAliquam.org", isCompany = false , Adress=new Adress{ StreetName = "P.O. Box 974, 6867 Et, Street", StreetNr = "34", City = new City{ZIP = "8117", CityName = "Chicago", Country = "Cook Islands" } } },
                new Person{ FirstName = "Melinda", LastName = "Copeland", Email = "Suspendisse.commodo@dictum.org", isCompany = false ,Adress = new Adress{ StreetName = "7613 Vel, St.", StreetNr = "53", City = new City{ZIP = "239706", CityName = "Sulzbach", Country = "Sri Lanka" } } },
                new Person{ FirstName = "Charissa", LastName = "Mcdonald", Email = "natoque.penatibus.et@tempusscelerisque.org", isCompany = false ,Adress = new Adress{ StreetName = "P.O. Box 713, 5777 Nullam St.", StreetNr = "19", City = new City{ZIP = "36830", CityName = "Bard", Country = "Palestine, State of" } }},
                new Person{ FirstName = "Adena", LastName = "Morris", Email = "massa@magnaCras.org", isCompany = false ,Adress = new Adress{ StreetName = "Ap #332-3689 Aliquet, Ave", StreetNr = "84", City = new City{ZIP = "1737", CityName = "Wasseiges", Country = "Tokelau" } } },
                new Person{ FirstName = "Miriam", LastName = "Simpson", Email = "cursus@tellus.edu", isCompany = false ,Adress = new Adress{ StreetName = "2526 Ad Rd.", StreetNr = "56", City = new City{ZIP = "68-681", CityName = "Palakkad", Country = "Vanuatu" } } },
                new Person{ FirstName = "Peter", LastName = "Mckee", Email = "Nam.consequat.dolor@magnaSuspendissetristique.ca", isCompany = false,Adress = new Adress{ StreetName = "2370 Sem St.", StreetNr = "37", City = new City{ZIP = "6879", CityName = "Hastings", Country = "Hungary" } } },
                new Person{ FirstName = "Zelenia", LastName = "William", Email = "nec.tempus@erosnon.com", isCompany = false ,Adress = new Adress{ StreetName = "370-1059 Luctus Street", StreetNr = "43",City = new City{ ZIP = "37592", CityName = "Cuenca", Country = "Latvia" } } },
                new Person{ FirstName = "Jonah", LastName = "Coffey", Email = "Quisque.purus.sapien@litoratorquentper.com",isCompany = false ,Adress = new Adress{ StreetName = "P.O. Box 559, 5217 Risus Street", StreetNr = "52", City = new City{ZIP = "69676", CityName = "Bassano in Teverina", Country = "Swaziland" } } },
                new Person{ FirstName = "Griffith",LastName = "Abbott", Email = "non@Curabitur.ca", isCompany = false,Adress = new Adress{ StreetName = "5525 Vel Av.", StreetNr = "25", City = new City{ZIP = "76722-283", CityName = "Gijón", Country = "Saint Helena, Ascension and Tristan da Cunha" } } },
                new Person{ FirstName = "Jared", LastName = "Gallagher", Email = "ligula.Nullam.enim@ametdapibusid.co.uk", isCompany =false,Adress = new Adress { StreetName = "9442 Non, St.", StreetNr = "66", City = new City{ZIP = "32897", CityName = "Sars-la-Buissire", Country = "Guadeloupe" } } },
                new Person{ FirstName = "Zeph", LastName = "Guerrero", Email = "Curabitur.egestas.nunc@eleifendnunc.co.uk", isCompany = false,Adress = new Adress{ StreetName = "5792 Vitae Road", StreetNr = "84", City = new City{ZIP = "M0R 2Z2", CityName = "Saint-Remy", Country = "Belarus" } } },
                new Person{ FirstName = "Wyoming", LastName = "Spence", Email = "ac.feugiat.non@Donectemporest.net", isCompany = false ,Adress = new Adress{ StreetName = "2649 Pede Rd.", StreetNr = "65", City = new City{ZIP = "79263", CityName = "Glendon", Country = "Indonesia" } } },
                new Person{ FirstName = "Rinah", LastName = "House", Email = "nisl.Quisque.fringilla@et.net", isCompany = false,Adress = new Adress { StreetName = "P.O. Box 773, 8652 Dolor. St.", StreetNr = "87", City = new City{ZIP = "60579", CityName = "Saint-Nicolas", Country = "Pakistan" } } },
                new Person{ FirstName = "Miranda", LastName = "Rowland", Email = "quam.dignissim.pharetra@Aliquam.ca", isCompany = false ,Adress = new Adress{ StreetName = "828-3556 Cursus Street", StreetNr = "14", City = new City{ZIP = "98290", CityName = "Oudekapelle", Country = "Burkina Faso" } } },
                new Person{ FirstName = "Lance", LastName = "Lowe", Email = "Cum@fringillaDonec.ca", isCompany = false,Adress = new Adress { StreetName = "307-168 Lacus. Road", StreetNr = "73", City = new City{ZIP = "2593", CityName = "Campinas", Country = "Hungary" } } },
                new Person{ FirstName = "Diana", LastName = "Kirk", Email = "arcu.Vestibulum.ante@Integer.ca", isCompany = false,Adress = new Adress{ StreetName = "952-5795 Tellus Rd.", StreetNr = "52", City = new City{ZIP = "11007", CityName = "Berlin", Country = "Seychelles" } }},
                new Person{ LastName = "Integer Vitae Nibh Company", Email = "ligula.Aenean@leoCras.org", isCompany = true,Adress = new Adress{ StreetName = "P.O. Box 278, 8526 Egestas. Road", StreetNr = "16", City = new City{ZIP = "652209", CityName = "Habay", Country = "Netherlands" } } },
                new Person{ LastName =  "Aliquam Gravida Mauris LLP", Email = "mollis@euaccumsan.com", isCompany =true ,Adress = new Adress{ StreetName = "5154 Aliquam Rd.", StreetNr = "9", City = new City{ZIP = "58094", CityName = "Curepto", Country = "Mayotte" } } },
                new Person{ LastName = "Interdum Feugiat Ltd", Email = "Ut@felisadipiscing.org", isCompany = true ,Adress = new Adress{ StreetName = "4991 Laoreet, St.", StreetNr = "33", City = new City{ZIP = "13883", CityName = "Chambord", Country = "Tonga" } } },
                new Person{ LastName = "Metus Vivamus Foundation", Email = "Sed.eget@ipsumportaelit.net", isCompany = true,Adress = new Adress { StreetName = "P.O. Box 681, 9411 Ut, Street", StreetNr = "67", City = new City{ZIP = "78596-714", CityName = "Alto Biobío", Country = "Nauru" } } },
                new Person{ LastName = "Massa PC", Email = "tempus@enimcommodo.ca", isCompany = true,Adress = new Adress { StreetName = "P.O. Box 606, 8089 Ut Ave", StreetNr = "82", City = new City{ZIP = "66111", CityName = "Bonnyville", Country = "United Arab Emirates" } } },
                new Person{ LastName = "Leo In Company" , Email = "netus@Quisque.org", isCompany = true ,Adress = new Adress{ StreetName = "Ap #772-6684 In Road", StreetNr = "39", City = new City{ZIP = "50996", CityName = "Piła", Country = "Cyprus" } } },
                new Person { LastName = "Morbi Accumsan Institute" , Email = "posuere@purus.co.uk", isCompany = true ,Adress = new Adress{ StreetName = "P.O. Box 386, 513 Feugiat. Rd.", StreetNr = "22", City = new City{ZIP = "65914", CityName = "Mejillones", Country = "Burkina Faso" } } },
                new Person{ LastName = "Arcu Ac Orci Ltd", Email = "Nunc.pulvinar@id.co.uk", isCompany = true,Adress = new Adress { StreetName = "3850 Velit Ave", StreetNr = "79", City = new City{ZIP = "B4G 6W2", CityName = "Rengo", Country = "Burundi" } } },
                new Person{ FirstName = "Joshua", LastName = "Phelps", Email = "at@nunc.co.uk", isCompany = false ,Adress = new Adress{ StreetName = "5492 Consectetuer Rd.", StreetNr = "38", City = new City{ZIP = "4037", CityName = "Lille", Country = "Tanzania" } } },
                new Person{ FirstName = "Shana", LastName = "Estrada", Email = "tellus.Suspendisse.sed@cubilia.com", isCompany =false,Adress = new Adress { StreetName = "Ap #911-8529 Orci. Rd.", StreetNr = "60", City = new City{ZIP = "JZ4 0EK", CityName = "Perquenco", Country = "Jamaica" } }},
                new Person{ FirstName = "Theodore", LastName = "Bruce", Email = "nostra.per@Nunclectuspede.edu", isCompany = false ,Adress = new Adress{ StreetName = "370-1059 Luctus Street", StreetNr = "43", City = new City{ZIP = "37592", CityName = "Cuenca", Country = "Latvia" }} } };
                context.Persons.AddOrUpdate(data);

                var packets = new Packet[] {
                new Packet{ Typ = "Brief", FilePath = "Mazda", DeliveryDate = DateTime.ParseExact("30.06.17", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver = data[2], Sender = data[2] },
                new Packet{ Typ = "Email", FilePath = "Mazda", DeliveryDate = DateTime.ParseExact("09.03.18", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver = data[18], Sender =data[ 1] },
                new Packet{ Typ = "Email", FilePath = "FAW", DeliveryDate = DateTime.ParseExact("29.09.18", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver = data[1], Sender = data[7] },
                new Packet{ Typ = "Email", FilePath = "Hyundai Motors", DeliveryDate = DateTime.ParseExact("06.08.17", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver = data[10], Sender =data[ 20] },
                new Packet{ Typ = "Brief", FilePath = "Lincoln", DeliveryDate = DateTime.ParseExact("29.10.18", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver = data[12], Sender = data[9] },
                new Packet{ Typ = "RsB", FilePath = "Kenworth", DeliveryDate = DateTime.ParseExact("03.10.18", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver = data[20], Sender = data[15] },
                new Packet{ Typ = "Brief", FilePath = "Fiat", DeliveryDate = DateTime.ParseExact("13.08.17", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver =data[0], Sender = data[8] },
                new Packet{ Typ = "Email", FilePath = "General Motors", DeliveryDate = DateTime.ParseExact("04.03.19", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver =data[ 16],Sender = data[1] },
                new Packet{ Typ = "RsB", FilePath = "Mercedes-Benz", DeliveryDate = DateTime.ParseExact("02.09.17", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver = data[9], Sender =data[ 11] },
                new Packet{ Typ = "RsB", FilePath = "Peugeot", DeliveryDate = DateTime.ParseExact("06.06.18", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver = data[10], Sender = data[13 ]},
                new Packet{ Typ = "Email", FilePath = "Mitsubishi Motors", DeliveryDate = DateTime.ParseExact("20.08.18", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver =data[ 10], Sender =data[ 19 ]},
                new Packet { Typ = "Brief", FilePath = "Tata Motors", DeliveryDate = DateTime.ParseExact("25.11.18", "dd.MM.yy", CultureInfo.InvariantCulture), Clerk = clerks[0], Receiver = data[10], Sender = data[16] } };
                context.Packets.AddOrUpdate(packets);
                context.SaveChanges();
            }
        }
        
        public override void Down()
        {
        }
    }
}
