namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDataInMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON ");
            Sql("INSERT INTO Movies (Id,Name,ReleaseDate , DateAdded , NumberInStock , Genre_Id ) VALUES (1,'Hangover','9-6-2009', '5-4-2016' , 5 , 1 )");
        }
        
        public override void Down()
        {
        }
    }
}
