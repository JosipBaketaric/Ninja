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
    [RoutePrefix("api/clan")]
    public class ClanController : ApiController
    {
        public static IUnitOfWork unitOfWork;

        
        public ClanController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }



        [HttpGet]
        [ActionName("GetClanById")]
        public HttpResponseMessage GetClanById(int id)
        {
            try
            {
                if (id < 0 || id == null)
                {
                    throw new ArgumentNullException("Id not valid");
                }

                var response = Mapper.Map<ClanView>(unitOfWork.Clans.Get(id));
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
        [ActionName("GetClanWithNinjasById")]
        public HttpResponseMessage GetClanWithNinjasById(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentNullException("Id not valid");
                }

                var response = Mapper.Map<ClanWithNinjasView>(unitOfWork.Clans.GetClanWithNinjas(id));
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
        [ActionName("GetAllClans")]
        public HttpResponseMessage GetAllClans()
        {
            try
            {
                var response = Mapper.Map<List<ClanView>>(unitOfWork.Clans.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message); 
            }
        }




    }
}