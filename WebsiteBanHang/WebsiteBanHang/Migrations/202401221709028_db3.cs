namespace WebsiteBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Post", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Post", "CreateBy", c => c.String());
            AddColumn("dbo.tb_Post", "ModifierDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Post", "ModifierBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Post", "ModifierBy");
            DropColumn("dbo.tb_Post", "ModifierDate");
            DropColumn("dbo.tb_Post", "CreateBy");
            DropColumn("dbo.tb_Post", "CreateDate");
        }
    }
}
