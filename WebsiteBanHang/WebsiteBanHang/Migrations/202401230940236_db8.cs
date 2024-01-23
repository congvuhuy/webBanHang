namespace WebsiteBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Post", "page");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Post", "page", c => c.Int(nullable: false));
        }
    }
}
