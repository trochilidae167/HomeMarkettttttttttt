namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase661 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangGiaChoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NCUId = c.Int(nullable: false),
                        MaThucPham = c.String(maxLength: 50),
                        TenThucPham = c.String(maxLength: 250),
                        LoaiThucPham = c.String(maxLength: 50),
                        GiaThucPham = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BangGiaChoes");
        }
    }
}
