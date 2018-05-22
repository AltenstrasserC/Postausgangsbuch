namespace PabDbLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _bool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filters", "Brief", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "Email", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "RsA", c => c.Boolean(nullable: false));
            AddColumn("dbo.Filters", "RsB", c => c.Boolean(nullable: false));
            DropColumn("dbo.Filters", "Typ");


        }
        
        public override void Down()
        {
            AddColumn("dbo.Filters", "Typ", c => c.String());
            DropColumn("dbo.Filters", "RsB");
            DropColumn("dbo.Filters", "RsA");
            DropColumn("dbo.Filters", "Email");
            DropColumn("dbo.Filters", "Brief");
        }
    }
}
