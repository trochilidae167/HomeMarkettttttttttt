namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdatabase16 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.NguoiDiChoOnlines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NguoiDiChoOnlines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Online = c.Boolean(nullable: false),
                        Refuse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
