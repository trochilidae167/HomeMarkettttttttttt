namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _236 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "X", c => c.Double(nullable: false));
            AddColumn("dbo.KhachHang", "Y", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHang", "Y");
            DropColumn("dbo.KhachHang", "X");
        }
    }
}
