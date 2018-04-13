namespace PabDbLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        StreetNr = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostCode = c.String(),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Business = c.Boolean(nullable: false),
                        Adress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresses", t => t.Adress_Id)
                .Index(t => t.Adress_Id);
            
            CreateTable(
                "dbo.Packets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Typ = c.String(),
                        FilePath = c.String(),
                        DeliveryDate = c.DateTime(),
                        Clerk_Id = c.Int(),
                        Receiver_Id = c.Int(),
                        Sender_Id = c.Int(),
                        Person_Id = c.Int(),
                        Person_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clerks", t => t.Clerk_Id)
                .ForeignKey("dbo.People", t => t.Receiver_Id)
                .ForeignKey("dbo.People", t => t.Sender_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.People", t => t.Person_Id1)
                .Index(t => t.Clerk_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Person_Id1);
            
            CreateTable(
                "dbo.Clerks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Filters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Typ = c.String(),
                        MinDate = c.DateTime(nullable: false),
                        MaxDate = c.DateTime(nullable: false),
                        SenderZIP = c.String(),
                        ReceiverZIP = c.String(),
                        Clerk_Id = c.Int(),
                        Receiver_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clerks", t => t.Clerk_Id)
                .ForeignKey("dbo.People", t => t.Receiver_Id)
                .ForeignKey("dbo.People", t => t.Sender_Id)
                .Index(t => t.Clerk_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filters", "Sender_Id", "dbo.People");
            DropForeignKey("dbo.Filters", "Receiver_Id", "dbo.People");
            DropForeignKey("dbo.Filters", "Clerk_Id", "dbo.Clerks");
            DropForeignKey("dbo.Packets", "Person_Id1", "dbo.People");
            DropForeignKey("dbo.Packets", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Packets", "Sender_Id", "dbo.People");
            DropForeignKey("dbo.Packets", "Receiver_Id", "dbo.People");
            DropForeignKey("dbo.Packets", "Clerk_Id", "dbo.Clerks");
            DropForeignKey("dbo.People", "Adress_Id", "dbo.Adresses");
            DropForeignKey("dbo.Adresses", "City_Id", "dbo.Cities");
            DropIndex("dbo.Filters", new[] { "Sender_Id" });
            DropIndex("dbo.Filters", new[] { "Receiver_Id" });
            DropIndex("dbo.Filters", new[] { "Clerk_Id" });
            DropIndex("dbo.Packets", new[] { "Person_Id1" });
            DropIndex("dbo.Packets", new[] { "Person_Id" });
            DropIndex("dbo.Packets", new[] { "Sender_Id" });
            DropIndex("dbo.Packets", new[] { "Receiver_Id" });
            DropIndex("dbo.Packets", new[] { "Clerk_Id" });
            DropIndex("dbo.People", new[] { "Adress_Id" });
            DropIndex("dbo.Adresses", new[] { "City_Id" });
            DropTable("dbo.Filters");
            DropTable("dbo.Clerks");
            DropTable("dbo.Packets");
            DropTable("dbo.People");
            DropTable("dbo.Cities");
            DropTable("dbo.Adresses");
        }
    }
}
