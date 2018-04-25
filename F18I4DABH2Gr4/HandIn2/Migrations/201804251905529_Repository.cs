namespace HandIn2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repository : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "CPR", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "CPR");
        }
    }
}
