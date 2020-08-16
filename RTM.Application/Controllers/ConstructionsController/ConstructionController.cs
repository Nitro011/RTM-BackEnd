using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.TableDB;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.ConstructionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Constructions> _GenericRepository;

        public ConstructionController(IUnitOfWork UnitOfWork, IGenericRepository<Constructions> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Construction
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetConstructions = await _UnitOfWork.context.Constructions.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetConstructions 
                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = false,
                    message = "Ocurrio un error inesperado!!",
                    data = ex.Message
                });
            }



        }

        // GET: api/Constructions/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetConstructions = await _UnitOfWork.context.Constructions.Where(x => x.ConstructionID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetConstructions
                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = false,
                    message = "Ocurrio un error inesperado!!",
                    data = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> registrar([FromBody] Constructions constructions)
        {
            try
            {


                await _GenericRepository.Add(constructions);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Constructions se registro correctamente",
                    data = constructions
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Constructions no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Construction/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Constructions constructions)
        {
            try
            {

                await _GenericRepository.Update(constructions);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = constructions

                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = false,
                    message = "Se produjo un error inesperado!!",
                    data = ex.Message
                });
            }

        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}