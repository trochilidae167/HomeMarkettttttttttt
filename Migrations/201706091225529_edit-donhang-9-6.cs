namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdonhang96 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonHang", "KhachHangId", "dbo.KhachHang");
            Sql("ALTER TABLE dbo.DonHang DROP CONSTRAINT FK_DonHang_KhachHang");
        }
        
        public override void Down()
        {
        }
    }
}
