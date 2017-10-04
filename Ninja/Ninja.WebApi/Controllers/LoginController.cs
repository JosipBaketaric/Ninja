using Ninja.LoginToken;
using Ninja.Repository.UnitOfWork;
using Ninja.View;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ninja.WebApi.Controllers
{

    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {

        protected IUnitOfWork unitOfWork;

        public LoginController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }





        [HttpGet]
        [ActionName("LoginNinja")]
        public HttpResponseMessage LoginNinja(string name, string password)
        {
            try
            {
                if (name == null || password == null || name == "" || password == "")
                {
                    throw new ArgumentNullException("Credentials not valid");
                }                

                //Generate token
                TokenGenerator tokenGenerator = new TokenGenerator();
                var token = tokenGenerator.GenerateToken();

                int ninjaId = unitOfWork.Ninjas.LoginNinja(name, password, token);

                if (ninjaId == -1)
                {
                    throw new ArgumentNullException("Credentials not valid");
                }

                int fComplete = unitOfWork.Complete();

                if (fComplete == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to save token.");
                }


                TokenAndIdView response = new TokenAndIdView();
                response.Token = token;
                response.NinjaId = ninjaId;


                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ArgumentNullException eNull)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, eNull.Message);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }





    }


}
