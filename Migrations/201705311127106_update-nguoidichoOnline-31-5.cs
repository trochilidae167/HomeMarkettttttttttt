namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatenguoidichoOnline315 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NguoiDiChoOnline", "Refuse", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NguoiDiChoOnline", "Refuse");
        }
    }
}
