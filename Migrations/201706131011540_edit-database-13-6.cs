namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdatabase136 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonHangChiTiet", "DonHangId", "dbo.DonHang");
            DropIndex("dbo.DonHangChiTiet", new[] { "DonHangId" });
            AddColumn("dbo.BangGiaChoes", "KhoiLuong", c => c.Single(nullable: false));
            AddColumn("dbo.BangGiaSieuThi", "KhoiLuong", c => c.Single(nullable: false));
            AlterColumn("dbo.DonHangChiTiet", "DonHangId", c => c.Int(nullable: false));
            AlterColumn("dbo.DonHangChiTiet", "ThucPhamId", c => c.Int(nullable: false));
            AlterColumn("dbo.DonHangChiTiet", "SoLuong", c => c.Double(nullable: false));
            AlterColumn("dbo.DonHangChiTiet", "Gia", c => c.Double(nullable: false));
            AlterColumn("dbo.DonHangChiTiet", "NCUId", c => c.Int(nullable: false));
            CreateIndex("dbo.DonHangChiTiet", "DonHangId");
            AddForeignKey("dbo.DonHangChiTiet", "DonHangId", "dbo.DonHang", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHangChiTiet", "DonHangId", "dbo.DonHang");
            DropIndex("dbo.DonHangChiTiet", new[] { "DonHangId" });
            AlterColumn("dbo.DonHangChiTiet", "NCUId", c => c.Int());
            AlterColumn("dbo.DonHangChiTiet", "Gia", c => c.Double());
            AlterColumn("dbo.DonHangChiTiet", "SoLuong", c => c.Double());
            AlterColumn("dbo.DonHangChiTiet", "ThucPhamId", c => c.Int());
            AlterColumn("dbo.DonHangChiTiet", "DonHangId", c => c.Int());
            DropColumn("dbo.BangGiaSieuThi", "KhoiLuong");
            DropColumn("dbo.BangGiaChoes", "KhoiLuong");
            CreateIndex("dbo.DonHangChiTiet", "DonHangId");
            AddForeignKey("dbo.DonHangChiTiet", "DonHangId", "dbo.DonHang", "Id");
        }
    }
}
