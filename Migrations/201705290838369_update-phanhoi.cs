namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatephanhoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanHoi", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhanHoi", "Status");
        }
    }
}
