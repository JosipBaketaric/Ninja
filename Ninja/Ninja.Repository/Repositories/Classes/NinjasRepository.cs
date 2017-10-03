
using Ninja.Data;
using System;
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

        public bool LoginNinja(string Name, string password, string token)
        {
            var ninja = FindOne(x => x.Name == Name && x.Password == password);

            if (ninja == null)
            {
                return false;
            }

            ninja.Token = token;
            ninja.TokenExpirationTime = DateTime.Now.AddMinutes(10);

            Update(ninja);

            return true;
        }

        public bool RefreshToken(int id)
        {
            var ninja = Get(id);

            if (ninja == null)
                return false;

            ninja.TokenExpirationTime = DateTime.Now.AddMinutes(10);
            return true;
        }

        public bool IsUserLogedIn(int id)
        {
            var ninja = Get(id);

            if (ninja == null)
                return false;

            if (ninja.Token == null)
                return false;

            if (ninja.TokenExpirationTime == null)
                return false;

            if (ninja.TokenExpirationTime < DateTime.Now)
                return false;

            return true;
        }


    }
}
