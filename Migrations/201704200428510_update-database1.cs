namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "UserName", c => c.String(maxLength: 50));
            AddColumn("dbo.KhachHang", "Password", c => c.String(maxLength: 32));
            AddColumn("dbo.NguoiDiCho", "UserName", c => c.String(maxLength: 50));
            AddColumn("dbo.NguoiDiCho", "Password", c => c.String(maxLength: 32));
            DropColumn("dbo.KhachHang", "TaiKhoan");
            DropColumn("dbo.KhachHang", "MatKhau");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KhachHang", "MatKhau", c => c.String(maxLength: 32));
            AddColumn("dbo.KhachHang", "TaiKhoan", c => c.String(maxLength: 50));
            DropColumn("dbo.NguoiDiCho", "Password");
            DropColumn("dbo.NguoiDiCho", "UserName");
            DropColumn("dbo.KhachHang", "Password");
            DropColumn("dbo.KhachHang", "UserName");
        }
    }
}
