namespace GamesStudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedBasicUsers : DbMigration
    {
        public override void Up()
        {
            // add admin@admin and user@user
            Sql(@"
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3de0941f-a9d1-418d-b1f6-7811c139fde4', N'user@user.com', 0, N'AB2vyv60EflZnUQE2GnbDCwb1gsxYT4LNZjrk+C0ZlBi0jphoPr+ewG/aMz97V14Gg==', N'0f38ee4c-7754-4e72-93ad-5c921e65adee', NULL, 0, 0, NULL, 1, 0, N'user@user.com')
        INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'80d9483e-8e91-4246-b5f0-ee55161327cb', N'admin@admin.com', 0, N'AC2k7s9/GR2odhyBCwFnWnhg3QIuj5tpld3Z8BN4D+YLH+zINR1CwgHCe0o1Kqzigw==', N'f6acf53e-5b00-4a03-ab91-d5f35901c4bd', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
       
        INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5176e98f-cf99-4b61-a6a9-6588776d4d4b', N'Admin')

        INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'80d9483e-8e91-4246-b5f0-ee55161327cb', N'5176e98f-cf99-4b61-a6a9-6588776d4d4b')

        
");
        }

        public override void Down()
        {
        }
    }
}
