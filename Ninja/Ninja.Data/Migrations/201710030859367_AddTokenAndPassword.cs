namespace Ninja.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTokenAndPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "Password", c => c.String());
            AddColumn("dbo.Ninjas", "Token", c => c.String());
            AddColumn("dbo.Ninjas", "TokenExpirationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ninjas", "TokenExpirationTime");
            DropColumn("dbo.Ninjas", "Token");
            DropColumn("dbo.Ninjas", "Password");
        }
    }
}
