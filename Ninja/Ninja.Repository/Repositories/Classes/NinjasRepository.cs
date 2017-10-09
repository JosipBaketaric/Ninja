
using AutoMapper;
using Ninja.Data;
using Ninja.View;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Ninja.Repository.Repositories
{
    public class NinjasRepository : GenericRepository<Ninja.Domain.Ninja>, INinjasRepository
    {

        public NinjasRepository(NinjaContext context)
            : base(context)
        {
        }

        //Casts a DbContext from generic repository to PersonEntities Context
        private NinjaContext NinjaContext
        {
            get { return Context as NinjaContext; }
        }


        //CUSTOM QUERIES GOES BELLOW

        //Reference().load() For properties with single entity
        //Collection().Load() for collections
        public NinjaWithClan GetNinjaWithClan(int id)
        {
            if(id < 0)
                throw new ArgumentNullException("Id not valid");

            var ninja = NinjaContext.Ninjas.Where(x => x.Id == id).FirstOrDefault();
            NinjaContext.Entry(ninja).Reference(n=> n.Clan).Load();

            return Mapper.Map<NinjaWithClan>(ninja);
        }



        public void RemoveNinjaFromClan(int id)
        {
            SqlParameter param1 = new SqlParameter("@Id", id);
            NinjaContext
                .Database
                .SqlQuery<object>("RemoveNinjaFromClanSP @Id", param1)
                .SingleOrDefault();
        }

        public void AddNinjaToClan(int ninjaId, int clanId)
        {
            SqlParameter param1 = new SqlParameter("@ninjaId", ninjaId);
            SqlParameter param2 = new SqlParameter("@clanId", clanId);
            NinjaContext
                .Database
                .SqlQuery<object>("AddNinjaToClanSP @ninjaId, @clanId", param1, param2)
                .SingleOrDefault();
        }







        public Ninja.Domain.Ninja LoginNinja(string Name, string password, string token)
        {
            var ninja = FindOne(x => x.Name == Name && x.Password == password);

            if (ninja == null)
            {
                return null;
            }

            ninja.Token = token;
            Update(ninja);

            return ninja;
        }




        /// <summary>
        /// 1 - OK
        /// -1 - Ninja not found
        /// -2 - Token not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IsUserLogedIn(int id)
        {
            var ninja = Get(id);

            if (ninja == null)
                return -1;

            if (ninja.Token == null)
                return -2;

            return 1;
        }


    }
}
