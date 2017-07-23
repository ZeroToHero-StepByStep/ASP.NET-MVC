namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopuateBirthDateInCustomersTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '1-1-1980' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
