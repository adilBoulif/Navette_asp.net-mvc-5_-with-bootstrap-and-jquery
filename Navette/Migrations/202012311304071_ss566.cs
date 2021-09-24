namespace Navette.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss566 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Strans", "image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Strans", "image", c => c.String(nullable: false));
        }
    }
}
