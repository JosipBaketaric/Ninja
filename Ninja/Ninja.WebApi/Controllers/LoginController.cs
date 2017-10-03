using Ninja.LoginToken;
using Ninja.Repository.UnitOfWork;
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

                unitOfWork.Ninjas.LoginNinja(name, password, token);
                int fComplete = unitOfWork.Complete();

                if (fComplete == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to save token.");
                }

                var response = token;
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
