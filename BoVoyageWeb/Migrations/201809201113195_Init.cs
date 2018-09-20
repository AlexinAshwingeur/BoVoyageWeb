namespace BoVoyageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgenceVoyages",
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
                .ForeignKey("dbo.AgenceVoyages", t => t.IdAgenceVoyage, cascadeDelete: false)
                .ForeignKey("dbo.Destinations", t => t.IdDestination, cascadeDelete: false)
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
                "dbo.DossierReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroCarteBancaire = c.String(nullable: false),
                        PrixParPersonne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdVoyage = c.Int(nullable: false),
                        IdClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.IdClient, cascadeDelete: false)
                .ForeignKey("dbo.Voyages", t => t.IdVoyage, cascadeDelete: false)
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
                .ForeignKey("dbo.DossierReservations", t => t.DossierReservation_Id)
                .Index(t => t.DossierReservation_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Civilite = c.String(),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroUnique = c.Int(nullable: false),
                        Reduction = c.Single(nullable: false),
                        Civilite = c.String(),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        DossierReservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DossierReservations", t => t.DossierReservation_Id)
                .Index(t => t.DossierReservation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DossierReservations", "IdVoyage", "dbo.Voyages");
            DropForeignKey("dbo.Participants", "DossierReservation_Id", "dbo.DossierReservations");
            DropForeignKey("dbo.DossierReservations", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Assurances", "DossierReservation_Id", "dbo.DossierReservations");
            DropForeignKey("dbo.Voyages", "IdDestination", "dbo.Destinations");
            DropForeignKey("dbo.Voyages", "IdAgenceVoyage", "dbo.AgenceVoyages");
            DropIndex("dbo.Participants", new[] { "DossierReservation_Id" });
            DropIndex("dbo.Assurances", new[] { "DossierReservation_Id" });
            DropIndex("dbo.DossierReservations", new[] { "IdClient" });
            DropIndex("dbo.DossierReservations", new[] { "IdVoyage" });
            DropIndex("dbo.Voyages", new[] { "IdDestination" });
            DropIndex("dbo.Voyages", new[] { "IdAgenceVoyage" });
            DropTable("dbo.Participants");
            DropTable("dbo.Clients");
            DropTable("dbo.Assurances");
            DropTable("dbo.DossierReservations");
            DropTable("dbo.Destinations");
            DropTable("dbo.Voyages");
            DropTable("dbo.AgenceVoyages");
        }
    }
}
