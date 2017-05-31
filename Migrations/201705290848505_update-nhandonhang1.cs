namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatenhandonhang1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanDonHang", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanDonHang", "Status");
        }
    }
}
