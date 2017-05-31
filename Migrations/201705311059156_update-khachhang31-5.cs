namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatekhachhang315 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHang", "X", c => c.Double(nullable: false));
            AddColumn("dbo.DonHang", "Y", c => c.Double(nullable: false));
            DropColumn("dbo.KhachHang", "X");
            DropColumn("dbo.KhachHang", "Y");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KhachHang", "Y", c => c.Double(nullable: false));
            AddColumn("dbo.KhachHang", "X", c => c.Double(nullable: false));
            DropColumn("dbo.DonHang", "Y");
            DropColumn("dbo.DonHang", "X");
        }
    }
}
