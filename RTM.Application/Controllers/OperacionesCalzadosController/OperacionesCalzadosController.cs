using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.OperacionesCalzados;
using RTM.Models.TableDB;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.OperacionesCalzadosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesCalzadosController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<OperacionesCalzados> _GenericRepository;

        public OperacionesCalzadosController(IUnitOfWork UnitOfWork, IGenericRepository<OperacionesCalzados> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/OperacionesCalzados
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetOperacionesCalzados = await _UnitOfWork.context.OperacionesCalzados.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOperacionesCalzados
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

        // GET: api/OperacionesCalzados/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetOperacionesCalzados = await _UnitOfWork.context.OperacionesCalzados.Where(x => x.OperacionesCalzadosID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOperacionesCalzados
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

        [HttpGet]
        [Route("[action]/{PartNo}")]
        public async Task<IActionResult> ConsultarOperacionesCalzadosPorPartNo([FromRoute]string PartNo)
        {
            try
            {
                var GetOperacionesCalzados = await OperacionesCalzadosPorPartNo(PartNo);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOperacionesCalzados
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
        public async Task<IActionResult> registrar([FromBody] OperacionesCalzados operacionesCalzados)
        {
            try
            {


                await _GenericRepository.Add(operacionesCalzados);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Operación de Calzado se registro correctamente",
                    data = operacionesCalzados
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Operación de Calzado no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/OperacionesCalzados/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] OperacionesCalzados operacionesCalzados)
        {
            try
            {

                await _GenericRepository.Update(operacionesCalzados);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = operacionesCalzados

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
        private async Task<List<OperacionesCalzadosListView>> OperacionesCalzadosPorPartNo(string PartNo)
        {
            var OperacionesCalzadosList = new List<OperacionesCalzadosListView>();

            OperacionesCalzadosList = await _UnitOfWork.context.OperacionesCalzados
                .Where(a => a.PartNo==PartNo)
                .Select(a => new OperacionesCalzadosListView()
                {
                    OperacionesCalzadosID=a.OperacionesCalzadosID,
                    PartNo=a.PartNo,
                    CantidadOperaciones=a.CantidadOperaciones,
                    Descripcion=a.Descripcion,
                    CostoOperacional=a.CostoOperacional

                }).ToListAsync();

            return OperacionesCalzadosList;
        }
    }
}