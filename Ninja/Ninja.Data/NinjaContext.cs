using Ninja.Domain;
using System;
using System.Data.Entity;
using System.Linq;

namespace Ninja.Data
{
    public class NinjaContext : DbContext
    {

        public NinjaContext()
            : base(@"Data Source=(local)\JOSIP;Initial Catalog=NinjaDB;Integrated Security=True")
        {
        }


        public virtual DbSet<Ninja.Domain.Ninja> Ninjas { get; set; }
        public virtual DbSet<Clan> Clans { get; set; }
        public virtual DbSet<Equipment> Equipement { get; set; }


        //Override save to update DateModified and/or DateCreated every time it saves in database
        public override int SaveChanges()
        {
            var selectedList = ChangeTracker.Entries()
                .Where(x => x.Entity is IModificationHistory &&
                    (x.State == EntityState.Added || x.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationHistory);

            foreach (var history in selectedList)
            {
                history.DateModified = DateTime.Now;

                if (history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }

            int result = base.SaveChanges();
            return result;
        }



    }

}
