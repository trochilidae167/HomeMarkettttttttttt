namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase315 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NguoiDiChoOnline",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Online = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiDiCho", t => t.Id, cascadeDelete:true)
                .Index(t => t.Id);
            
            DropColumn("dbo.NguoiDiCho", "X");
            DropColumn("dbo.NguoiDiCho", "Y");
            DropColumn("dbo.NguoiDiCho", "Online");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NguoiDiCho", "Online", c => c.Boolean(nullable: false));
            AddColumn("dbo.NguoiDiCho", "Y", c => c.Double(nullable: false));
            AddColumn("dbo.NguoiDiCho", "X", c => c.Double(nullable: false));
            DropForeignKey("dbo.NguoiDiChoOnline", "Id", "dbo.NguoiDiCho");
            DropIndex("dbo.NguoiDiChoOnlines", new[] { "Id" });
            DropTable("dbo.NguoiDiChoOnlines");
        }
    }
}
