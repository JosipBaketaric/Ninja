namespace Ninja.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVirtualListsAndAttributesForNavigation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "Ninja_Id", c => c.Int());
            AddColumn("dbo.Ninjas", "Clan_Id", c => c.Int());
            CreateIndex("dbo.Ninjas", "Clan_Id");
            CreateIndex("dbo.Equipments", "Ninja_Id");
            AddForeignKey("dbo.Ninjas", "Clan_Id", "dbo.Clans", "Id");
            AddForeignKey("dbo.Equipments", "Ninja_Id", "dbo.Ninjas", "Id");
            DropColumn("dbo.Equipments", "NinjaId");
            DropColumn("dbo.Ninjas", "ClanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ninjas", "ClanId", c => c.Int(nullable: false));
            AddColumn("dbo.Equipments", "NinjaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Equipments", "Ninja_Id", "dbo.Ninjas");
            DropForeignKey("dbo.Ninjas", "Clan_Id", "dbo.Clans");
            DropIndex("dbo.Equipments", new[] { "Ninja_Id" });
            DropIndex("dbo.Ninjas", new[] { "Clan_Id" });
            DropColumn("dbo.Ninjas", "Clan_Id");
            DropColumn("dbo.Equipments", "Ninja_Id");
        }
    }
}
