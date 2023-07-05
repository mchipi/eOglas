namespace Oglasi_Proekt_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "UserViews", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ads", "UserViews");
        }
    }
}
