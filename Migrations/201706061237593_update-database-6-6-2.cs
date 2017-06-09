namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase662 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHang", "NgayDangKy", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.KhachHang", "NguoiDiCho", c => c.Boolean(nullable: false));
            AlterColumn("dbo.KhachHang", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHang", "Status", c => c.Boolean());
            AlterColumn("dbo.KhachHang", "NguoiDiCho", c => c.Boolean());
            AlterColumn("dbo.KhachHang", "NgayDangKy", c => c.DateTime(storeType: "date"));
        }
    }
}
