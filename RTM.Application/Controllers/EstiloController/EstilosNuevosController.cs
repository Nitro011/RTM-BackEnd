using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTM.Models;
using RTM.Models.TableDB;
using RTM.Repository.Interface;


namespace RTM.Application.Controllers.EstiloController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstilosNuevosController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Estilos> _GenericRepository;

        public EstilosNuevosController(IUnitOfWork UnitOfWork, IGenericRepository<Estilos> GenericRepository)
        {
            this._GenericRepository = GenericRepository;
            this._UnitOfWork = UnitOfWork; 
        }
       
     

        // GET: api/<EstilosNuevosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EstilosNuevosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EstilosNuevosController>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> registrar([FromBody] Estilos estilos)
        {
            try
            {


                await _GenericRepository.Add(estilos);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Marca se registro correctamente"
                    
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Marca no se registro correctamente!!",
                    data = ex.Message
                });
            }

        }

        // PUT api/<EstilosNuevosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstilosNuevosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
