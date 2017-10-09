namespace Ninja.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoredProcedureRemoveNinjaFromClan : DbMigration
    {
        public override void Up()
        {

            CreateStoredProcedure(
                "RemoveNinjaFromClanSP", p => new
                {
                    Id = p.Int()
                },
                body:
                @"UPDATE [dbo].[Ninjas]
                    SET [Clan_Id] = NULL
                    WHERE ([Id] = @Id);
                    SELECT @@ROWCOUNT
                   "
                );
        }

        public override void Down()
        {
            DropStoredProcedure("RemoveNinjaFromClanSP");
        }
    }
}
