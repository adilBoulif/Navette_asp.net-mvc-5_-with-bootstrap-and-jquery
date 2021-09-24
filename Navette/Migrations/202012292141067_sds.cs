namespace Navette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false),
                        depart = c.String(nullable: false),
                        destination = c.String(nullable: false),
                        h_depart = c.String(nullable: false),
                        h_retour = c.String(nullable: false),
                        place = c.String(nullable: false),
                        prix = c.String(nullable: false),
                        stransId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Strans", t => t.stransId, cascadeDelete: true)
                .Index(t => t.stransId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offres", "stransId", "dbo.Strans");
            DropIndex("dbo.Offres", new[] { "stransId" });
            DropTable("dbo.Offres");
        }
    }
}
