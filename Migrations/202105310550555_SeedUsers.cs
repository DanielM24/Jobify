namespace Jobify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bfa1e39b-f149-4f42-915c-1bf1db839914', N'danielsimionov10@gmail.com', 0, N'AMehrdvFYO4EztmRYR4cV8I/rMyzP1OSlJ5Ubb5AEivkK3nSQ03EoEkoIWSigUVIYg==', N'c458be9c-27b4-48bd-9a39-ba136dc1b35a', NULL, 0, 0, NULL, 1, 0, N'danielsimionov10@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cfb4a0e9-3651-4daf-a770-06cf392360d0', N'applicant@jobify.ro', 0, N'AMp8Zi654rUkN15W6w9P8QfK6XLkl/8FcXNZd4T6EXmMoO+RpNk/kJxODTFw295nzg==', N'd3de40d8-1b20-4340-ad93-59163bdac98c', NULL, 0, 0, NULL, 1, 0, N'applicant@jobify.ro')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cfcfe30b-f2c9-42ac-87f4-269156b1df58', N'recruiter@jobify.ro', 0, N'AJPtWPQmMqA//5pk+7h0j0WSBc5GDw1ItQGNtO5UA1ttTUO9BXZa1LQHq1ms5LezGA==', N'8459f081-08d2-4c76-9af3-982cc355376f', NULL, 0, 0, NULL, 1, 0, N'recruiter@jobify.ro')
           
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0aaa0bff-120d-4c99-9280-bf90d34a8fa1', N'ApplicantUser')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ef8bbcfc-15d7-4fcb-a17f-8651aef5b2e6', N'RecruiterUser')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cfb4a0e9-3651-4daf-a770-06cf392360d0', N'0aaa0bff-120d-4c99-9280-bf90d34a8fa1')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cfcfe30b-f2c9-42ac-87f4-269156b1df58', N'ef8bbcfc-15d7-4fcb-a17f-8651aef5b2e6')

            ");
        }
       
        public override void Down()
        {
        }
    }
}
