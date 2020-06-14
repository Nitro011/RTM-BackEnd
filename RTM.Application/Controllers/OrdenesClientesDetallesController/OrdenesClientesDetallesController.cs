using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.OrdenesClientesDetallesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesClientesDetallesController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Ordenes_Clientes_Detalles> _GenericRepository;

        public OrdenesClientesDetallesController(IUnitOfWork UnitOfWork, IGenericRepository<Ordenes_Clientes_Detalles> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Ordenes_Clientes_Detalles
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetOrdenesClientesDetalles = await _UnitOfWork.context.Ordenes_Clientes_Detalles.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOrdenesClientesDetalles
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

        // GET: api/Ordenes_Clientes_Detalles/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetOrdenesClientesDetalles = await _UnitOfWork.context.Ordenes_Clientes_Detalles.Where(x => x.Orden_Cliente_DetalleID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOrdenesClientesDetalles
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
        public async Task<IActionResult> registrar([FromBody] Ordenes_Clientes_Detalles ordenes_Clientes_Detalles)
        {
            try
            {


                await _GenericRepository.Add(ordenes_Clientes_Detalles);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Orden del Cliente Detalle se registro correctamente",
                    data = ordenes_Clientes_Detalles
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Orden del Cliente Detalle no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Ordenes_Clientes_Detalles/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Ordenes_Clientes_Detalles ordenes_Clientes_Detalles)
        {
            try
            {

                await _GenericRepository.Update(ordenes_Clientes_Detalles);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = ordenes_Clientes_Detalles

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