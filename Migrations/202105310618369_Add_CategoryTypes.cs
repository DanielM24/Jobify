namespace Jobify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Add_CategoryTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Categories SET CategoryName = 'Artificial Intelligence' WHERE CategoryId = 1");
            Sql("UPDATE Categories SET CategoryName = 'Business Software Development' WHERE CategoryId = 2");
            Sql("UPDATE Categories SET CategoryName = 'Mobile' WHERE CategoryId = 3");
            Sql("UPDATE Categories SET CategoryName = 'Networking' WHERE CategoryId = 4");
            Sql("UPDATE Categories SET CategoryName = 'Gaming and Computer Graphics' WHERE CategoryId = 5");
            Sql("UPDATE Categories SET CategoryName = 'Cloud computing' WHERE CategoryId = 6");
            Sql("UPDATE Categories SET CategoryName = 'Embedded & Internet of Things' WHERE CategoryId = 7");
            Sql("UPDATE Categories SET CategoryName = 'Cybersecurity' WHERE CategoryId = 8");
            Sql("UPDATE Categories SET CategoryName = 'Database' WHERE CategoryId = 9");
            Sql("UPDATE Categories SET CategoryName = 'Web' WHERE CategoryId = 10");
            Sql("UPDATE Categories SET CategoryName = 'QA & Technical Support' WHERE CategoryId = 11");
            Sql("UPDATE Categories SET CategoryName = 'Banking' WHERE CategoryId = 12");
        }

        public override void Down()
        {
        }
    }
}
