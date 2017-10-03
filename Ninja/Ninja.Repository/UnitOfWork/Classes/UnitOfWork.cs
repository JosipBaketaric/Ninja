
using Ninja.Data;
using Ninja.Repository.Repositories;
using System;
namespace Ninja.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NinjaContext Context; 

        public IClansRepository Clans { get; set; }
        public IEquipmentRepository Equipment { get; set; }
        public INinjasRepository Ninjas { get; set; }

        public UnitOfWork(NinjaContext context, IClansRepository clans, 
            IEquipmentRepository equipment, INinjasRepository ninjas)
        {

            try
            {
                if (context == null || clans == null || equipment == null || ninjas == null)
                {
                    throw new ArgumentNullException("Arguments not valid");
                }

                Context = context;
                Clans = clans;
                Equipment = equipment;
                Ninjas = ninjas;
            }
            catch (ArgumentNullException eNull)
            {
                throw eNull;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int Complete()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Dispose()
        {
            try
            {
                Context.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }

}
