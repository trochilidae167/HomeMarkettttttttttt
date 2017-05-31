namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatenguoidicho2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NguoiDiCho", "TaiKhoan", c => c.Double(nullable: false));
            AlterColumn("dbo.NguoiDiCho", "NgayDangKy", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.NguoiDiCho", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NguoiDiCho", "Status", c => c.Boolean());
            AlterColumn("dbo.NguoiDiCho", "NgayDangKy", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.NguoiDiCho", "TaiKhoan", c => c.Double());
        }
    }
}
