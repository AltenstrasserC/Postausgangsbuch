namespace PabDbLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBNameSplitted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "ZIP", c => c.String());
            AddColumn("dbo.Cities", "CityName", c => c.String());
            AddColumn("dbo.People", "FirstName", c => c.String());
            AddColumn("dbo.People", "LastName", c => c.String());
            AddColumn("dbo.People", "isCompany", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "FilterName", c => c.String());
            AddColumn("dbo.Filters", "isLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "isEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "isRsA", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "isRsB", c => c.Boolean(nullable: false));
            DropColumn("dbo.Cities", "PostCode");
            DropColumn("dbo.Cities", "Name");
            DropColumn("dbo.People", "Name");
            DropColumn("dbo.People", "Business");
            DropColumn("dbo.Filters", "Name");
            DropColumn("dbo.Filters", "Brief");
            DropColumn("dbo.Filters", "Email");
            DropColumn("dbo.Filters", "RsA");
            DropColumn("dbo.Filters", "RsB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Filters", "RsB", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "RsA", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "Email", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "Brief", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "Name", c => c.String());
            AddColumn("dbo.People", "Business", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "Name", c => c.String());
            AddColumn("dbo.Cities", "Name", c => c.String());
            AddColumn("dbo.Cities", "PostCode", c => c.String());
            DropColumn("dbo.Filters", "isRsB");
            DropColumn("dbo.Filters", "isRsA");
            DropColumn("dbo.Filters", "isEmail");
            DropColumn("dbo.Filters", "isLetter");
            DropColumn("dbo.Filters", "FilterName");
            DropColumn("dbo.People", "isCompany");
            DropColumn("dbo.People", "LastName");
            DropColumn("dbo.People", "FirstName");
            DropColumn("dbo.Cities", "CityName");
            DropColumn("dbo.Cities", "ZIP");
        }
    }
}
