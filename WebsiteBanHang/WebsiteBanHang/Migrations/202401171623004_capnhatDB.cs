namespace WebsiteBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnhatDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_New", "Title", c => c.String());
            DropColumn("dbo.tb_New", "Ttile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_New", "Ttile", c => c.String());
            DropColumn("dbo.tb_New", "Title");
        }
    }
}
