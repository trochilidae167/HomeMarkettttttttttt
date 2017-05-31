namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_databaseNguoiDiCho : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NguoiDiCho", "X", c => c.Double(nullable: false));
            AlterColumn("dbo.NguoiDiCho", "Y", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NguoiDiCho", "Y", c => c.Double());
            AlterColumn("dbo.NguoiDiCho", "X", c => c.Double());
        }
    }
}
