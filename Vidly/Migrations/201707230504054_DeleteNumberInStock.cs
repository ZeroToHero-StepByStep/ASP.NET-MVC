namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteNumberInStock : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.DateTime(nullable: false));
        }
    }
}
