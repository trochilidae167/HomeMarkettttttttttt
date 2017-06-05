namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editnguoidichoonline : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NguoiDiChoOnline", "Id", "dbo.NguoiDiCho");
            DropIndex("dbo.NguoiDiChoOnline", new[] { "Id" });
            DropPrimaryKey("dbo.NguoiDiChoOnline");
            AlterColumn("dbo.NguoiDiChoOnline", "Id", c => c.Int(nullable: false, identity: false));
            AddPrimaryKey("dbo.NguoiDiChoOnline", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.NguoiDiChoOnline");
            AlterColumn("dbo.NguoiDiChoOnline", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.NguoiDiChoOnline", "Id");
            CreateIndex("dbo.NguoiDiChoOnline", "Id");
            AddForeignKey("dbo.NguoiDiChoOnline", "Id", "dbo.NguoiDiCho", "Id");
        }
    }
}
