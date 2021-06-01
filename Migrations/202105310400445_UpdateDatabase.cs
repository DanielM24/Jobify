namespace Jobify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "City", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "City", c => c.String(nullable: false));
        }
    }
}
