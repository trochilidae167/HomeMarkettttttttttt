namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewnguoidichoonline : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NguoiDiChoOnlines",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Online = c.Boolean(nullable: false),
                        Refuse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NguoiDiChoOnlines");
        }
    }
}
