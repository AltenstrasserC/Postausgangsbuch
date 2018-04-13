namespace PabDbLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DBSeed : DbMigration
    {
        public override void Up()
        {
            using (var db = new PabDBContext())
            {
                var clerk1 = new Clerk { Name = "jreidinger", Password = "1234" };
                var clerk2 = new Clerk { Name = "caltenstraﬂer", Password = "1234" };
                var clerk3 = new Clerk { Name = "jr", Password = "" };
                var clerk4 = new Clerk { Name = "ca", Password = "" };

                var city1 = new City { Name = "Linz", PostCode = "4010", Country = "Austria" };
                var city2 = new City { Name = "Eferding", PostCode = "4070", Country = "Austria" };
                var city3 = new City { Name = "Dorf an der Pram", PostCode = "4751", Country = "Austria" };
                var city4 = new City { Name = "Riedau", PostCode = "4752", Country = "Austria" };

                var person1 = new Person
                {
                    Name = "Sepp",
                    Email = "sepp@gmx.at",
                    Business = false,
                    Adress = new Adress
                    {
                        StreetName = "Waldweg",
                        StreetNr = "5",
                        City = city1
                    }
                };
                var person2 = new Person
                {
                    Name = "Hans Berger",
                    Email = "hansWurst@gmx.at",
                    Business = false,
                    Adress = new Adress
                    {
                        StreetName = "Bachstraﬂe",
                        StreetNr = "23",
                        City = city2
                    }
                };
                var person3 = new Person
                {
                    Name = "Fritz Reifinger",
                    Email = "reifingerAuto@gmx.at",
                    Business = true,
                    Adress = new Adress
                    {
                        StreetName = "Bergstraﬂe",
                        StreetNr = "34",
                        City = city3
                    }
                };
                var person4 = new Person
                {
                    Name = "Sarah Haslinger",
                    Email = "anwalt@gmail.com",
                    Business = true,
                    Adress = new Adress
                    {
                        StreetName = "Kallhammerstraﬂe",
                        StreetNr = "8",
                        City = city4
                    }
                };

                db.Packets.Add(new Packet
                {
                    Clerk = clerk4,
                    DeliveryDate = DateTime.Parse("10.03.2009"),
                    FilePath = "email1.txt",
                    Receiver = person1,
                    Sender = person2,
                    Typ = "Email"
                });
                db.Packets.Add(new Packet
                {
                    Clerk = clerk1,
                    DeliveryDate = DateTime.Parse("15.05.2010"),
                    FilePath = "rsa.txt",
                    Receiver = person1,
                    Sender = person4,
                    Typ = "RsA"
                });
                db.Packets.Add(new Packet
                {
                    Clerk = clerk4,
                    DeliveryDate = DateTime.Parse("28.02.2009"),
                    FilePath = "flyer.txt",
                    Receiver = person3,
                    Sender = person4,
                    Typ = "RsB"
                });
                db.Packets.Add(new Packet
                {
                    Clerk = clerk3,
                    DeliveryDate = DateTime.Parse("07.12.2010"),
                    FilePath = "datei.txt",
                    Receiver = person4,
                    Sender = person1,
                    Typ = "Email"
                });
                db.Packets.Add(new Packet
                {
                    Clerk = clerk2,
                    DeliveryDate = DateTime.Parse("23.10.2012"),
                    FilePath = "flyer.txt",
                    Receiver = person3,
                    Sender = person4,
                    Typ = "RsB"
                });
                db.Packets.Add(new Packet
                {
                    Clerk = clerk3,
                    DeliveryDate = DateTime.Parse("01.06.2012"),
                    FilePath = "file.txt",
                    Receiver = person4,
                    Sender = person1,
                    Typ = "Email"
                });
                db.Packets.Add(new Packet
                {
                    Clerk = clerk3,
                    DeliveryDate = DateTime.Parse("22.11.2012"),
                    FilePath = "email.txt",
                    Receiver = person3,
                    Sender = person4,
                    Typ = "Email"
                });
                db.Packets.Add(new Packet
                {
                    Clerk = clerk1,
                    DeliveryDate = DateTime.Parse("02.12.2012"),
                    FilePath = "brief.txt",
                    Receiver = person4,
                    Sender = person1,
                    Typ = "Brief"
                });
                db.SaveChanges();
            }

        }

        public override void Down()
        {

        }
    }
}
