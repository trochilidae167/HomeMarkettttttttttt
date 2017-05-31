namespace HomeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_bangia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BangGiaCho", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BangGiaCho", "GiaThucPham", c => c.Double(nullable: false));
            AlterColumn("dbo.BangGiaSieuThi", "GiaThucPham", c => c.Double(nullable: false));
            AlterColumn("dbo.BangGiaSieuThi", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BangGiaSieuThi", "Status", c => c.Boolean());
            AlterColumn("dbo.BangGiaSieuThi", "GiaThucPham", c => c.Double());
            AlterColumn("dbo.BangGiaCho", "GiaThucPham", c => c.Double());
            DropColumn("dbo.BangGiaCho", "Status");
        }
    }
}
