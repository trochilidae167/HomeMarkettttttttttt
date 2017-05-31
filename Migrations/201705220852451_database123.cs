namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database123 : DbMigration
    {
        public override void Up()
        {
            //DropTable("dbo.Students");
        }
        
        public override void Down()
        {
            //    CreateTable(
            //        "dbo.Students",
            //        c => new
            //            {
            //                Id = c.Int(nullable: false, identity: true),
            //                FirstName = c.String(),
            //                LastName = c.String(),
            //                BirthDay = c.DateTime(nullable: false),
            //                Gender = c.String(),
            //                Address = c.String(),
            //            })
            //        .PrimaryKey(t => t.Id);

        }
    }
}
