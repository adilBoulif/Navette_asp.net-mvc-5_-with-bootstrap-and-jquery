namespace Navette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss56 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Strans", "image", c => c.String(nullable: false));
            DropColumn("dbo.Strans", "password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Strans", "password", c => c.String(nullable: false));
            AlterColumn("dbo.Strans", "image", c => c.String());
        }
    }
}
