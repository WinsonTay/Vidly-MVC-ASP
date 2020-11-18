namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a80b66dd-4248-46fe-a3c9-c9504b3f03c0', N'admin@vidly.com', 0, N'AC4sL2M9f57CNgUbPlUZqWvkcFpnTBKdmRNWlQtibpTX29mddXLC92N5qwJzUbid9w==', N'f1a72919-7047-49cf-b863-bdb2d2c51467', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd1428f06-d971-497d-ba0c-541b251a7046', N'guest@vidly.com', 0, N'AGyZDefXpoaVlUx190xgKHbjcC9Cdi3EbFNryRu4ZcrPejaihoY0SsTCnyTF0MVTlA==', N'61fdede2-5f66-40bf-87a4-5ebb9b450f32', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'23a69913-aeff-488c-b232-9e35ea3824b9', N'CanManageMovie')
                    
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a80b66dd-4248-46fe-a3c9-c9504b3f03c0', N'23a69913-aeff-488c-b232-9e35ea3824b9')

        
                ");
        
        }
        
        public override void Down()
        {
        }
    }
}
