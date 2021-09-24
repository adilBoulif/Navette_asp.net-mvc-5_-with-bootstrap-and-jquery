namespace Navette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsd564 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date_Abon = c.DateTime(nullable: false),
                        OffreId = c.Int(nullable: false),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Offres", t => t.OffreId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.OffreId)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Abonments", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Abonments", "OffreId", "dbo.Offres");
            DropIndex("dbo.Abonments", new[] { "userId" });
            DropIndex("dbo.Abonments", new[] { "OffreId" });
            DropTable("dbo.Abonments");
        }
    }
}
