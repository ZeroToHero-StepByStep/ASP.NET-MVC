namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreAndForeignKeyToCustomerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Genre_Id");
            AddForeignKey("dbo.Customers", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Customers", new[] { "Genre_Id" });
            DropColumn("dbo.Customers", "Genre_Id");
            DropColumn("dbo.Customers", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
