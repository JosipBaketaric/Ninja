using AutoMapper;
using Ninja.Repository.UnitOfWork;
using Ninja.View;
using Ninja.WebApi.Authentication;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ninja.WebApi.Controllers
{

    [AuthenticateNinjaAttribute]
    [RoutePrefix("api/ninja")]
    public class NinjaController : ApiController
    {
        protected IUnitOfWork unitOfWork;

        public NinjaController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }


        [HttpGet]
        [ActionName("GetNinjaById")]
        public HttpResponseMessage GetNinjaById(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentNullException("Id not valid");
                }

                var response = Mapper.Map<NinjaView>(unitOfWork.Ninjas.Get(id));

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





        [HttpGet]
        [ActionName("GetNinjaWithClan")]
        public HttpResponseMessage GetNinjaWithClan(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentNullException("Id not valid");
                }

                var response = unitOfWork.Ninjas.GetNinjaWithClan(id);

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











        [HttpGet]
        [ActionName("GetAllNinjas")]
        public HttpResponseMessage GetAllNinjas()
        {
            try
            {
                var response = Mapper.Map<List<NinjaView>>(unitOfWork.Ninjas.GetAll());

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message); 
            }

        }





        [HttpPost]
        [ActionName("AddNinja")]
        public HttpResponseMessage AddNinja([FromBody]NinjaView ninja)
        {
            try
            {
                if (ninja == null)
                {
                    throw new ArgumentNullException("Model not valid");
                }

                unitOfWork.Ninjas.Add(Mapper.Map<Ninja.Domain.Ninja>(ninja));

                var response = unitOfWork.Complete();

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



        [HttpPost]
        [ActionName("AddNinjaToClan")]
        public HttpResponseMessage AddNinjaToClan(int ninjaId, int clanId)
        {
            try
            {
                if (ninjaId < 0 || clanId < 0)
                {
                    throw new ArgumentNullException("Arguments not valid");
                }

                if(unitOfWork.Ninjas.Get(ninjaId).Clan != null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, 
                        "You are already in clan! To join clan first leave current clan.");
                }

                unitOfWork.Ninjas.AddNinjaToClan(ninjaId, clanId);

                return Request.CreateResponse(HttpStatusCode.OK, 1);
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




        [HttpPut]
        [ActionName("RemoveNinjaFromClan")]
        public HttpResponseMessage RemoveNinjaFromClan(int id)
        {
            try
            {
                unitOfWork.Ninjas.RemoveNinjaFromClan(id);
                return Request.CreateResponse(HttpStatusCode.OK, 1);
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
