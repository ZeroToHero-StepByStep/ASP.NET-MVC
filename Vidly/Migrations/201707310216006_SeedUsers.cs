namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'46c204c5-9c62-4062-8ff9-204bbf85783b', N'guest@vidly.com', 0, N'AM3KAv2SNGHo2RSeL/tUXmaI9tznzr903fvSY3PFZG2bDQEWOZTj0iTJBrphJ2ZnUg==', N'9be868b0-05a8-4c5b-ba19-e64cb25fb3bd', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ce21077d-1c8f-405e-9d31-903bc5861947', N'admin@vidly.com', 0, N'ACgwCPQyPEjMwEtsvarEeE1RQZE/v0q6FXsBBM/elPfv6nni8kfAo4ttEn+nLX7Wgw==', N'6d7db1e6-f04c-4282-b6ba-ae59af298415', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'39375b67-16f0-4dc2-81c6-0bef9157962b', N'CanManagedMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ce21077d-1c8f-405e-9d31-903bc5861947', N'39375b67-16f0-4dc2-81c6-0bef9157962b')
");
        }
        
        public override void Down()
        {
        }
    }
}
