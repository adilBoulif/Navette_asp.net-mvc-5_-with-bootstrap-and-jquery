namespace Navette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class df54 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DemandeClients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        depart = c.String(),
                        destination = c.String(),
                        h_depart = c.String(),
                        h_destination = c.String(),
                        num_demande = c.Int(nullable: false),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DemandeClients", "userId", "dbo.AspNetUsers");
            DropIndex("dbo.DemandeClients", new[] { "userId" });
            DropTable("dbo.DemandeClients");
        }
    }
}
