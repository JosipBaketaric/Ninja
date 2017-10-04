using Ninja.Repository.Repositories;
using Ninja.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ninja.WebApi.Authentication
{
    public class AuthenticateNinjaAttribute : AuthorizeAttribute
    {

        public AuthenticateNinjaAttribute()
        {
        }


        /// <summary>
        /// Ninja is Authorized only if he is loged in by rulles of IsUserLogedIn method and if token is equal that in DB!
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>

        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var context = new Data.NinjaContext();
            UnitOfWork uow = new UnitOfWork(context, new ClansRepository(context),
                new EquipmentRepository(context), new NinjasRepository(context));


            IEnumerable<string> idHeader;
            IEnumerable<string> tokenHeader;

            bool fHasHeader = false;

            fHasHeader = actionContext.Request.Headers.TryGetValues("NinjaId", out idHeader);

            if (!fHasHeader)
                return false;

            fHasHeader = actionContext.Request.Headers.TryGetValues("Token", out tokenHeader);

            if (!fHasHeader)
                return false;



            int id;
            string token;

            int.TryParse(idHeader.First(), out id);
            token = tokenHeader.First();



            var result = uow.Ninjas.IsUserLogedIn(id);

            if (result != 1)
                return false;



            var realToken = uow.Ninjas.Get(id).Token;

            if (realToken != token)
                return false;

            return true;
        }

    }
}