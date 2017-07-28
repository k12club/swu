namespace Swu.Portal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_NickName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalTestData", "NickName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalTestData", "NickName");
        }
    }
}
