namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedonhang2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonHang", "KhachHangId", "dbo.KhachHang");
            DropIndex("dbo.DonHang", new[] { "KhachHangId" });
            AlterColumn("dbo.DonHang", "KhachHangId", c => c.Int(nullable: false));
            AlterColumn("dbo.DonHang", "NCUId", c => c.Int(nullable: false));
            AlterColumn("dbo.DonHang", "ThoiGianDat", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DonHang", "DaNhan", c => c.Boolean(nullable: false));
            CreateIndex("dbo.DonHang", "KhachHangId");
            AddForeignKey("dbo.DonHang", "KhachHangId", "dbo.KhachHang", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHang", "KhachHangId", "dbo.KhachHang");
            DropIndex("dbo.DonHang", new[] { "KhachHangId" });
            AlterColumn("dbo.DonHang", "DaNhan", c => c.Boolean());
            AlterColumn("dbo.DonHang", "ThoiGianDat", c => c.DateTime());
            AlterColumn("dbo.DonHang", "NCUId", c => c.Int());
            AlterColumn("dbo.DonHang", "KhachHangId", c => c.Int());
            CreateIndex("dbo.DonHang", "KhachHangId");
            AddForeignKey("dbo.DonHang", "KhachHangId", "dbo.KhachHang", "Id");
        }
    }
}
