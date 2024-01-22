namespace WebsiteBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Post", "Image", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Post", "Image", c => c.String(maxLength: 250));
        }
    }
}
