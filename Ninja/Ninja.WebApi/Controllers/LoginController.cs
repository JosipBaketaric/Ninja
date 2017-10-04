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


        [HttpPost]
        [ActionName("LogoutNinja")]
        public HttpResponseMessage LogoutNinja(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentNullException("Id not valid");
                }

                var ninja = unitOfWork.Ninjas.Get(id);

                if(ninja == null)
                {
                    throw new ArgumentNullException("Id not valid");
                }

                ninja.Token = null;
                int response = unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);

            }
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

                var ninja = unitOfWork.Ninjas.LoginNinja(name, password, token);

                if (ninja == null)
                {
                    throw new ArgumentNullException("Credentials not valid");
                }

                int fComplete = unitOfWork.Complete();

                if (fComplete == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to save token.");
                }


                TokenAndIdView response = new TokenAndIdView();
                response.Token = ninja.Token;
                response.NinjaId = ninja.Id;


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
