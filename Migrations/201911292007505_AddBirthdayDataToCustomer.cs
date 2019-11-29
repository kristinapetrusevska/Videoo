namespace Videoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayDataToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday='12/12/2012' WHERE Id=1");
            
            
        }
        
        public override void Down()
        {
        }
    }
}
