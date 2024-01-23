namespace WebsiteBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Post", "page", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Post", "page");
        }
    }
}
