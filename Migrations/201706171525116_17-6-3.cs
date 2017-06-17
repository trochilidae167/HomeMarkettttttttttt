namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1763 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhanDonHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonHangId = c.Int(nullable: false),
                        NguoiDiChoId = c.Int(nullable: false),
                        ThoiGianNhan = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhanDonHang");
        }
    }
}
