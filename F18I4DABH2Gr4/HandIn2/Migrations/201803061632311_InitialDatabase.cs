namespace HandIn2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdresseID = c.Int(nullable: false, identity: true),
                        Vejnavn = c.String(),
                        Husnummer = c.Int(nullable: false),
                        Type = c.String(),
                        By_Postnummer = c.Int(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.AdresseID)
                .ForeignKey("dbo.Bylistes", t => t.By_Postnummer)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.By_Postnummer)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Bylistes",
                c => new
                    {
                        Postnummer = c.Int(nullable: false, identity: true),
                        Bynavn = c.String(),
                    })
                .PrimaryKey(t => t.Postnummer);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Fornavn = c.String(),
                        Mellemnavn = c.String(),
                        Efternavn = c.String(),
                        Email = c.String(),
                        Type = c.String(),
                        PrimAdresse_AdresseID = c.Int(),
                        Personkartotek_PersonkartotekId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Adresses", t => t.PrimAdresse_AdresseID)
                .ForeignKey("dbo.Personkartoteks", t => t.Personkartotek_PersonkartotekId)
                .Index(t => t.PrimAdresse_AdresseID)
                .Index(t => t.Personkartotek_PersonkartotekId);
            
            CreateTable(
                "dbo.Telefons",
                c => new
                    {
                        Nummer = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Teleselskab = c.String(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Nummer)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Personkartoteks",
                c => new
                    {
                        PersonkartotekId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PersonkartotekId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Personkartotek_PersonkartotekId", "dbo.Personkartoteks");
            DropForeignKey("dbo.Adresses", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.People", "PrimAdresse_AdresseID", "dbo.Adresses");
            DropForeignKey("dbo.Telefons", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Adresses", "By_Postnummer", "dbo.Bylistes");
            DropIndex("dbo.Telefons", new[] { "Person_PersonId" });
            DropIndex("dbo.People", new[] { "Personkartotek_PersonkartotekId" });
            DropIndex("dbo.People", new[] { "PrimAdresse_AdresseID" });
            DropIndex("dbo.Adresses", new[] { "Person_PersonId" });
            DropIndex("dbo.Adresses", new[] { "By_Postnummer" });
            DropTable("dbo.Personkartoteks");
            DropTable("dbo.Telefons");
            DropTable("dbo.People");
            DropTable("dbo.Bylistes");
            DropTable("dbo.Adresses");
        }
    }
}
