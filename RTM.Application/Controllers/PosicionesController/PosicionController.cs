using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTM.Models.TableDB;
using RTM.Repository.Interface;
using RTM.Models;
using Microsoft.EntityFrameworkCore;
using RTM.Models.DTO.Posiciones;

namespace RTM.Application.Controllers.PosicionesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicionController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Posiciones> _GenericRepository;

        public PosicionController(IUnitOfWork UnitOfWork, IGenericRepository<Posiciones> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Posiciones
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetPosiciones = await _UnitOfWork.context.Posiciones.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetPosiciones
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

        // GET: api/Posiciones/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetPosiciones = await _UnitOfWork.context.Posiciones.Where(x => x.PosicionID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetPosiciones
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
        [Route("[action]/{Posicion}")]
        public async Task<IActionResult> ConsultarPosicionesPorPosicion([FromRoute]string Posicion)
        {
            try
            {
                var GetPosiciones = await BuscarPosicionPorPosicion(Posicion);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetPosiciones
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

        // GET: api/Departamentos
        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> DepartamentosList()
        //{
        //    try
        //    {

        //        var GetDepartamentos = await DepartamentosListViews();

        //        return Ok(new Request()
        //        {
        //            status = true,
        //            message = "Esta accion se ejecuto correctamente",
        //            data = GetDepartamentos
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new Request()
        //        {
        //            status = false,
        //            message = "Ocurrio un error inesperado!!",
        //            data = ex.Message
        //        });
        //    }



        //}

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> registrar([FromBody] Posiciones posiciones)
        {
            try
            {


                await _GenericRepository.Add(posiciones);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Posicion se registro correctamente",
                    data = posiciones
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Posicion no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Posiciones/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Posiciones posiciones)
        {
            try
            {

                await _GenericRepository.Update(posiciones);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = posiciones

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
        private async Task<List<PosicionesListView>> BuscarPosicionPorPosicion(string Posicion)
        {
            var PosicionList = new List<PosicionesListView>();

            PosicionList = await _UnitOfWork.context.Posiciones
           .Where(a => a.Posicion==Posicion)
           .Select(a => new PosicionesListView()
           {
               PosicionID=a.PosicionID,
               Posicion=a.Posicion,

           }).ToListAsync();

            return PosicionList;
        }
    }
}