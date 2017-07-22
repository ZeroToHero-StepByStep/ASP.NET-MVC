namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSinUpAttributeToSignUpFeeInMembershipTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SignUp", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
    }
}
