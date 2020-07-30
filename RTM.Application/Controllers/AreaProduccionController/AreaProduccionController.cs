using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.AreaProduccion;
using RTM.Repository.Interface;


namespace RTM.Application.Controllers.AreaProduccionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaProduccionController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<AreaProduccion> _GenericRepository;

        public AreaProduccionController(IUnitOfWork UnitOfWork, IGenericRepository<AreaProduccion> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/AreaProduccion
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetAreaProduccion = await _UnitOfWork.context.AreaProduccion.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetAreaProduccion
                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = true,
                    message = "Ocurrio un error inesperado!!",
                    data = ex.Message
                });
            }



        }

        // GET: api/AreaProduccion/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetAreaProduccion = await _UnitOfWork.context.AreaProduccion.Where(x => x.AreaProduccionID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetAreaProduccion
                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = false,
                    message = "Se produjo un error no esperado!!",
                    data = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("[action]/{NombreAreaProduccion}")]
        public async Task<IActionResult> BuscarAreaProduccionPorNombre([FromRoute]string NombreAreaProduccion)
        {
            try
            {
                var GetAreaProduccion = await AreasProduccionPorNombre(NombreAreaProduccion);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetAreaProduccion
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
        public async Task<IActionResult> registrar([FromBody] AreaProduccion areaProduccion)
        {
            try
            {


                await _GenericRepository.Add(areaProduccion);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Area de Produccion se registro correctamente",
                    data = areaProduccion
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Area de Produccion no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Usuarios/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] AreaProduccion areaProduccion)
        {
            try
            {

                await _GenericRepository.Update(areaProduccion);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = areaProduccion

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

        //Funciones:
        private async Task<List<AreaProduccionListView>> AreasProduccionPorNombre(string NombreAreaProduccion)
        {
            var AreaProduccionList = new List<AreaProduccionListView>();

                 AreaProduccionList = await _UnitOfWork.context.AreaProduccion
                .Where(a => a.NombreAreaProduccion==NombreAreaProduccion)
                .Select(a => new AreaProduccionListView()
                {
                    AreaProduccionID=a.AreaProduccionID,
                    NombreAreaProduccion=a.NombreAreaProduccion
                }).ToListAsync();

            return AreaProduccionList;
        }
    }
}