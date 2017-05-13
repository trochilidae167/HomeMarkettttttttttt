namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_RegistrationId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "RegistrationId", c => c.String(maxLength:8000));
        }

        public override void Down()
        {
            DropColumn("dbo.KhachHang", "RegistrationId");
        }
    }
}
