namespace Jobify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateParameters : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Salary", c => c.String(nullable: false));
            AlterColumn("dbo.Jobs", "City", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "City", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "Salary", c => c.Int(nullable: false));
        }
    }
}
