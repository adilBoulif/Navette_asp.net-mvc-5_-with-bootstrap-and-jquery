namespace Navette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdsdds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModifierViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        PasswordNew = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModifierViewModels");
        }
    }
}
