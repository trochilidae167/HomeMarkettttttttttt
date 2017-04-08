namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Password", c => c.String(maxLength: 32));
            AddColumn("dbo.Users", "GroupID", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Users", "GroupID");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
