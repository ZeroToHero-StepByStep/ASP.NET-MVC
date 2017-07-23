namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveGenreAndGenreIdPorpertyToMovieModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Customers", new[] { "Genre_Id" });
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
            DropColumn("dbo.Customers", "GenreId");
            DropColumn("dbo.Customers", "Genre_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Genre_Id", c => c.Int());
            AddColumn("dbo.Customers", "GenreId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "GenreId");
            CreateIndex("dbo.Customers", "Genre_Id");
            AddForeignKey("dbo.Customers", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
