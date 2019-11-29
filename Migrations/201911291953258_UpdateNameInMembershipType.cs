namespace Videoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameInMembershipType : DbMigration
    {
        public override void Up()
        {

            

            Sql("UPDATE MembershipTypes SET Name='As-You-Go' WHERE Id=1");
            Sql("UPDATE MembershipTypes SET Name='Montlhy' WHERE Id=2");
            Sql("UPDATE MembershipTypes SET Name='3-Months' WHERE Id=3");
            Sql("UPDATE MembershipTypes SET Name='Yearly' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
