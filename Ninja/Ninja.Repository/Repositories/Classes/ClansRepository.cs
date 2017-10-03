using AutoMapper;
using Ninja.Data;
using Ninja.Domain;
using Ninja.View;
using System;
using System.Linq;

namespace Ninja.Repository.Repositories
{
    public class ClansRepository : GenericRepository<Clan>, IClansRepository
    {

        public ClansRepository(NinjaContext context)
            : base(context)
        {
        }

        //Casts a DbContext from generic repository to PersonEntities Context
        private NinjaContext NinjaContext
        {
            get { return Context as NinjaContext; }
        }


        //CUSTOM QUERIES GOES BELLOW

        public ClanWithNinjasView GetClanWithNinjas(int id)
        {
            try
            {
                if (id == null || id < 0)
                {
                    throw new ArgumentNullException("Id not valid");
                }

                //Explicit Loading
                var clan = NinjaContext.Clans.Where(x => x.Id == id).FirstOrDefault();
                NinjaContext.Entry(clan).Collection(n => n.Ninjas).Load();

                //Map

                //TODO: MAPPING
                var result = Mapper.Map<ClanWithNinjasView>(clan);
                return result;
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



    }
}
