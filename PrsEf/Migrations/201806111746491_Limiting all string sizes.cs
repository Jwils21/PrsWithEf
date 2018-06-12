namespace PrsEf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Limitingallstringsizes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Lastname", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "Lastname", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
    }
}
