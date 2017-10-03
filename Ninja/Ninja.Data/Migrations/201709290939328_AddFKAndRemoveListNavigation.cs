namespace Ninja.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKAndRemoveListNavigation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ninjas", "Clan_Id", "dbo.Clans");
            DropForeignKey("dbo.Equipments", "Ninja_Id", "dbo.Ninjas");
            DropIndex("dbo.Equipments", new[] { "Ninja_Id" });
            DropIndex("dbo.Ninjas", new[] { "Clan_Id" });
            AddColumn("dbo.Equipments", "NinjaId", c => c.Int(nullable: false));
            AddColumn("dbo.Ninjas", "ClanId", c => c.Int(nullable: false));
            DropColumn("dbo.Equipments", "Ninja_Id");
            DropColumn("dbo.Ninjas", "Clan_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ninjas", "Clan_Id", c => c.Int());
            AddColumn("dbo.Equipments", "Ninja_Id", c => c.Int());
            DropColumn("dbo.Ninjas", "ClanId");
            DropColumn("dbo.Equipments", "NinjaId");
            CreateIndex("dbo.Ninjas", "Clan_Id");
            CreateIndex("dbo.Equipments", "Ninja_Id");
            AddForeignKey("dbo.Equipments", "Ninja_Id", "dbo.Ninjas", "Id");
            AddForeignKey("dbo.Ninjas", "Clan_Id", "dbo.Clans", "Id");
        }
    }
}
