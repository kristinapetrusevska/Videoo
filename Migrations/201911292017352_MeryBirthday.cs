namespace Videoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeryBirthday : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
