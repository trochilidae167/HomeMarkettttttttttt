namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dangnhap : DbMigration
    {
        public override void Up()
        {
            //    CreateTable(
            //        "dbo.Credential",
            //        c => new
            //            {
            //                UserGroupID = c.String(nullable: false, maxLength: 20),
            //                RoleID = c.String(maxLength: 50),
            //            })
            //        .PrimaryKey(t => t.UserGroupID);

        }
        
        public override void Down()
        {
            //DropTable("dbo.Credential");
        }
    }
}
