namespace BoVoyageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredPaysDestination : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Destinations", "Pays", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Destinations", "Pays", c => c.String());
        }
    }
}
