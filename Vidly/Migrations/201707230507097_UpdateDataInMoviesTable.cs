namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataInMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MOVIES SET NumberInStock = 5 WHERE Id = 1 ");
        }
        
        public override void Down()
        {
        }
    }
}
