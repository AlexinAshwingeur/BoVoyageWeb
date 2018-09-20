namespace BoVoyageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgencesVoyages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAller = c.DateTime(nullable: false),
                        DateRetour = c.DateTime(nullable: false),
                        PlacesDisponibles = c.Int(nullable: false),
                        PrixParPersonne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdAgenceVoyage = c.Int(nullable: false),
                        IdDestination = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgencesVoyages", t => t.IdAgenceVoyage, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.IdDestination, cascadeDelete: true)
                .Index(t => t.IdAgenceVoyage)
                .Index(t => t.IdDestination);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Continent = c.String(),
                        Pays = c.String(),
                        Region = c.String(),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DossiersReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroCarteBancaire = c.String(nullable: false),
                        PrixParPersonne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdVoyage = c.Int(nullable: false),
                        IdClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.IdClient, cascadeDelete: true)
                .ForeignKey("dbo.Voyages", t => t.IdVoyage, cascadeDelete: true)
                .Index(t => t.IdVoyage)
                .Index(t => t.IdClient);
            
            CreateTable(
                "dbo.Assurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(),
                        Code = c.Int(nullable: false),
                        DossierReservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DossiersReservations", t => t.DossierReservation_Id)
                .Index(t => t.DossierReservation_Id);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Civilite = c.String(),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        Email = c.String(),
                        NumeroUnique = c.Int(),
                        Reduction = c.Single(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        DossierReservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DossiersReservations", t => t.DossierReservation_Id)
                .Index(t => t.DossierReservation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DossiersReservations", "IdVoyage", "dbo.Voyages");
            DropForeignKey("dbo.Personnes", "DossierReservation_Id", "dbo.DossiersReservations");
            DropForeignKey("dbo.DossiersReservations", "IdClient", "dbo.Personnes");
            DropForeignKey("dbo.Assurances", "DossierReservation_Id", "dbo.DossiersReservations");
            DropForeignKey("dbo.Voyages", "IdDestination", "dbo.Destinations");
            DropForeignKey("dbo.Voyages", "IdAgenceVoyage", "dbo.AgencesVoyages");
            DropIndex("dbo.Personnes", new[] { "DossierReservation_Id" });
            DropIndex("dbo.Assurances", new[] { "DossierReservation_Id" });
            DropIndex("dbo.DossiersReservations", new[] { "IdClient" });
            DropIndex("dbo.DossiersReservations", new[] { "IdVoyage" });
            DropIndex("dbo.Voyages", new[] { "IdDestination" });
            DropIndex("dbo.Voyages", new[] { "IdAgenceVoyage" });
            DropTable("dbo.Personnes");
            DropTable("dbo.Assurances");
            DropTable("dbo.DossiersReservations");
            DropTable("dbo.Destinations");
            DropTable("dbo.Voyages");
            DropTable("dbo.AgencesVoyages");
        }
    }
}
