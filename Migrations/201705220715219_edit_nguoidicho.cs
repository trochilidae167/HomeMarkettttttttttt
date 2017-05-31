namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_nguoidicho : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NguoiDiCho", "Status", c => c.Boolean());
            AddColumn("dbo.NguoiDiCho", "X", c => c.Double(nullable: false));
            AddColumn("dbo.NguoiDiCho", "Y", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NguoiDiCho", "Y");
            DropColumn("dbo.NguoiDiCho", "X");
            DropColumn("dbo.NguoiDiCho", "Status");
        }
    }
}
