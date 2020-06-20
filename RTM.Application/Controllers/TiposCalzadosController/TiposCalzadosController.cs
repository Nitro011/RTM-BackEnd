using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Repository.Interface;
using RTM.Models;

namespace RTM.Application.Controllers.TiposCalzadosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposCalzadosController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Tipo_Calzados> _GenericRepository;

        public TiposCalzadosController(IUnitOfWork UnitOfWork, IGenericRepository<Tipo_Calzados> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/TiposCalzados
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetTiposCalzados = await _UnitOfWork.context.Tipo_Calzados.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetTiposCalzados
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

        // GET: api/TiposCalzados/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetTiposCalzados = await _UnitOfWork.context.Tipo_Calzados.Where(x => x.Tipo_CalzadoID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetTiposCalzados
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
        public async Task<IActionResult> registrar([FromBody] Tipo_Calzados tipo_Calzados)
        {
            try
            {


                await _GenericRepository.Add(tipo_Calzados);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Tipo de Calzado se registro correctamente",
                    data = tipo_Calzados
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Tipo de Calzado no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/TiposCalzados/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody]Tipo_Calzados tipo_Calzados)
        {
            try
            {

                await _GenericRepository.Update(tipo_Calzados);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = tipo_Calzados

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