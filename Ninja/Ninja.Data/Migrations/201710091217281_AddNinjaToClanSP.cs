namespace Ninja.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNinjaToClanSP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "AddNinjaToClanSP", p => new
                {
                    ninjaId = p.Int(),
                    clanId = p.Int()
                },
                body:
                @"UPDATE [dbo].[Ninjas]
                    SET [Clan_Id] = @clanId
                    WHERE ([Id] = @ninjaId);
                    SELECT @@ROWCOUNT
                   "
                );
        }
        
        public override void Down()
        {
            DropStoredProcedure("AddNinjaToClanSP");
        }
    }
}
