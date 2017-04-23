namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_banggia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BangGiaSieuThi", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BangGiaSieuThi", "Status");
        }
    }
}
