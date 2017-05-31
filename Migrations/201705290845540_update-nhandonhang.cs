namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatenhandonhang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanDonHang", "ThoiGianNhan", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanDonHang", "ThoiGianNhan", c => c.String(maxLength: 50));
        }
    }
}
