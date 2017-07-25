namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyGenreIdToMovieModel : DbMigration
    {
        public override void Up()
        {

            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
//            Sql("" +
//                "ALTER TABLE dbo.Movies WITH NOCHECK " +
//                "ADD CONTRAINT GenreId FOREIGN KEY(GenreId)" +
//                "REFERENCES dbo.Genres(Id)" +
//                "");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
