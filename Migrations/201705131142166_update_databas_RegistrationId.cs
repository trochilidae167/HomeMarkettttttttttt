namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_databas_RegistrationId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "RegistrationId", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHang", "RegistrationId");
        }
    }
}
