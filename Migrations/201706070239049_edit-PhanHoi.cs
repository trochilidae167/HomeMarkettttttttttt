namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPhanHoi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhanHoi", "NgayTao", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhanHoi", "NgayTao", c => c.DateTime(storeType: "date"));
        }
    }
}
