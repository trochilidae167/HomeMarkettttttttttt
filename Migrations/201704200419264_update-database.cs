namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "TaiKhoan", c => c.String(maxLength: 50));
            AddColumn("dbo.KhachHang", "MatKhau", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHang", "MatKhau");
            DropColumn("dbo.KhachHang", "TaiKhoan");
        }
    }
}
