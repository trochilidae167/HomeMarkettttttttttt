namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _166 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GiaDonHang", "DonHangId", "dbo.DonHang");
            DropIndex("dbo.GiaDonHang", new[] { "DonHangId" });
            AlterColumn("dbo.GiaDonHang", "DonHangId", c => c.Int(nullable: false));
            AlterColumn("dbo.GiaDonHang", "TongTien", c => c.Double(nullable: false));
            AlterColumn("dbo.GiaDonHang", "PhiDichVu", c => c.Double(nullable: false));
            CreateIndex("dbo.GiaDonHang", "DonHangId");
            AddForeignKey("dbo.GiaDonHang", "DonHangId", "dbo.DonHang", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GiaDonHang", "DonHangId", "dbo.DonHang");
            DropIndex("dbo.GiaDonHang", new[] { "DonHangId" });
            AlterColumn("dbo.GiaDonHang", "PhiDichVu", c => c.Double());
            AlterColumn("dbo.GiaDonHang", "TongTien", c => c.Double());
            AlterColumn("dbo.GiaDonHang", "DonHangId", c => c.Int());
            CreateIndex("dbo.GiaDonHang", "DonHangId");
            AddForeignKey("dbo.GiaDonHang", "DonHangId", "dbo.DonHang", "Id");
        }
    }
}
