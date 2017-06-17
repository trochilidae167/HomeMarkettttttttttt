namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1762 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.NhanDonHang");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NhanDonHang",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DonHangId = c.Int(nullable: false),
                        NguoiDiChoId = c.Int(nullable: false),
                        ThoiGianNhan = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
