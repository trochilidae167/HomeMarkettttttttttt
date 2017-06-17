namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _176 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanDonHang", "DonHangId", c => c.Int(nullable: false));
            AddColumn("dbo.NhanDonHang", "NguoiDiChoId", c => c.Int(nullable: false));
            DropColumn("dbo.NhanDonHang", "MaDonHang");
            DropColumn("dbo.NhanDonHang", "MaNguoiDiCho");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanDonHang", "MaNguoiDiCho", c => c.String(maxLength: 50));
            AddColumn("dbo.NhanDonHang", "MaDonHang", c => c.String(maxLength: 50));
            DropColumn("dbo.NhanDonHang", "NguoiDiChoId");
            DropColumn("dbo.NhanDonHang", "DonHangId");
        }
    }
}
