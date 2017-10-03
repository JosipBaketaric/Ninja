namespace Ninja.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Ninja_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ninjas", t => t.Ninja_Id)
                .Index(t => t.Ninja_Id);
            
            CreateTable(
                "dbo.Ninjas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Clan_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clans", t => t.Clan_Id)
                .Index(t => t.Clan_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "Ninja_Id", "dbo.Ninjas");
            DropForeignKey("dbo.Ninjas", "Clan_Id", "dbo.Clans");
            DropIndex("dbo.Ninjas", new[] { "Clan_Id" });
            DropIndex("dbo.Equipments", new[] { "Ninja_Id" });
            DropTable("dbo.Ninjas");
            DropTable("dbo.Equipments");
            DropTable("dbo.Clans");
        }
    }
}
