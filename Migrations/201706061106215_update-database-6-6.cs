namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase66 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhaCungUngs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ma = c.String(maxLength: 50),
                        Ten = c.String(maxLength: 250),
                        DiaChi = c.String(maxLength: 1024),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.BangGiaCho");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BangGiaCho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaThucPham = c.String(maxLength: 50),
                        TenThucPham = c.String(maxLength: 250),
                        LoaiThucPham = c.String(maxLength: 50),
                        GiaThucPham = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.NhaCungUngs");
        }
    }
}
