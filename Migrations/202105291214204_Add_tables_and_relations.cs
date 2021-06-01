namespace Jobify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_tables_and_relations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicantDetails",
                c => new
                    {
                        ApplicantDetailsId = c.Byte(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Bio = c.String(),
                        Experience = c.String(),
                        Education = c.String(),
                        Projects = c.String(),
                        Languages = c.String(),
                    })
                .PrimaryKey(t => t.ApplicantDetailsId)
                .ForeignKey("dbo.Applicants", t => t.ApplicantDetailsId)
                .Index(t => t.ApplicantDetailsId);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ApplicantId = c.Byte(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicantId);
            
            CreateTable(
                "dbo.ApplicantJobs",
                c => new
                    {
                        ApplicantId = c.Byte(nullable: false),
                        JobId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicantId, t.JobId })
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.ApplicantId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Byte(nullable: false),
                        JobName = c.String(nullable: false, maxLength: 100),
                        JobDescription = c.String(nullable: false),
                        DurationInMonths = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        City = c.Int(nullable: false),
                        IsRemote = c.Boolean(nullable: false),
                        CompanyId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Byte(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        JobId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Byte(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicantJobs", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Categories", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.ApplicantJobs", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.ApplicantDetails", "ApplicantDetailsId", "dbo.Applicants");
            DropIndex("dbo.Categories", new[] { "JobId" });
            DropIndex("dbo.Jobs", new[] { "CompanyId" });
            DropIndex("dbo.ApplicantJobs", new[] { "JobId" });
            DropIndex("dbo.ApplicantJobs", new[] { "ApplicantId" });
            DropIndex("dbo.ApplicantDetails", new[] { "ApplicantDetailsId" });
            DropTable("dbo.Companies");
            DropTable("dbo.Categories");
            DropTable("dbo.Jobs");
            DropTable("dbo.ApplicantJobs");
            DropTable("dbo.Applicants");
            DropTable("dbo.ApplicantDetails");
        }
    }
}
