namespace HandIn2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NyByfil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adresses", "By_Postnummer", "dbo.Bylistes");
            DropIndex("dbo.Adresses", new[] { "By_Postnummer" });
            CreateTable(
                "dbo.Bies",
                c => new
                    {
                        ById = c.Int(nullable: false, identity: true),
                        Postnummer = c.Int(nullable: false),
                        Bynavn = c.String(),
                    })
                .PrimaryKey(t => t.ById);
            
            AddColumn("dbo.Adresses", "Byer_ById", c => c.Int());
            CreateIndex("dbo.Adresses", "Byer_ById");
            AddForeignKey("dbo.Adresses", "Byer_ById", "dbo.Bies", "ById");
            DropColumn("dbo.Adresses", "By_Postnummer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bylistes",
                c => new
                    {
                        Postnummer = c.Int(nullable: false, identity: true),
                        Bynavn = c.String(),
                    })
                .PrimaryKey(t => t.Postnummer);
            
            AddColumn("dbo.Adresses", "By_Postnummer", c => c.Int());
            DropForeignKey("dbo.Adresses", "Byer_ById", "dbo.Bies");
            DropIndex("dbo.Adresses", new[] { "Byer_ById" });
            DropColumn("dbo.Adresses", "Byer_ById");
            DropTable("dbo.Bies");
            CreateIndex("dbo.Adresses", "By_Postnummer");
            AddForeignKey("dbo.Adresses", "By_Postnummer", "dbo.Bylistes", "Postnummer");
        }
    }
}
