namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateKhachHang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "CMND", c => c.String(maxLength: 50));
            AddColumn("dbo.KhachHang", "Status", c => c.Boolean());
            AddColumn("dbo.KhachHang", "X", c => c.Double(nullable: false));
            AddColumn("dbo.KhachHang", "Y", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHang", "Y");
            DropColumn("dbo.KhachHang", "X");
            DropColumn("dbo.KhachHang", "Status");
            DropColumn("dbo.KhachHang", "CMND");
        }
    }
}
