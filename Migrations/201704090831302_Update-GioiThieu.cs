namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGioiThieu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GioiThieu", "NguoiSuDung", c => c.Boolean());
            AddColumn("dbo.GioiThieu", "KhachHang", c => c.Boolean());
            AddColumn("dbo.GioiThieu", "NguoiDiCho", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GioiThieu", "NguoiDiCho");
            DropColumn("dbo.GioiThieu", "KhachHang");
            DropColumn("dbo.GioiThieu", "NguoiSuDung");
        }
    }
}
