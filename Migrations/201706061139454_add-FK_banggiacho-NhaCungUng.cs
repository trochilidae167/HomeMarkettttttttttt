namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFK_banggiachoNhaCungUng : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BangGiaChoes", "NCUId");
            AddForeignKey("dbo.BangGiaChoes", "NCUId", "dbo.NhaCungUngs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BangGiaChoes", "NCUId", "dbo.NhaCungUngs");
            DropIndex("dbo.BangGiaChoes", new[] { "NCUId" });
        }
    }
}
