namespace Ninja.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTokenExpirationTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ninjas", "TokenExpirationTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ninjas", "TokenExpirationTime", c => c.DateTime(nullable: false));
        }
    }
}
