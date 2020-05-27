using Microsoft.AspNetCore.Mvc;
using RTM.Models;
using RTM.Persistence;
using RTM.Repository;
using RTM.Repository.Interface;
using RTM.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RayTrackingMobile.Controllers
{
   // [Route("[action]")]
    public class PPSandyController : ApiController
    {

        private readonly IGenericRepository<Almacen> _GenericRepository;
        private readonly IUnitOfWork _unitOfWork;


       
        public PPSandyController(IGenericRepository<Almacen> GenericRepository, IUnitOfWork unitOfWork)
        {
            _GenericRepository = GenericRepository;
            _unitOfWork = unitOfWork;
        }

        public PPSandyController()
        {

        }

        // GET: api/PPSandy
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PPSandy/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PPSandy
        //[HttpPost]
        //[Route("[action]")]
        public IHttpActionResult Post([FromBody] Almacen almacen)
        {
         
            try
            {

                _GenericRepository.Add(almacen);
                _unitOfWork.Commit();
                return Ok(almacen);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
         

        }

        // PUT: api/PPSandy/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PPSandy/5
        public void Delete(int id)
        {
        }
    }
}
