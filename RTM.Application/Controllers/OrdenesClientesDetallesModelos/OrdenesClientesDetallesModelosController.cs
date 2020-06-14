using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.OrdenesClientesDetallesModelos
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesClientesDetallesModelosController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Ordenes_Clientes_Detalles_Modelos> _GenericRepository;

        public OrdenesClientesDetallesModelosController(IUnitOfWork UnitOfWork, IGenericRepository<Ordenes_Clientes_Detalles_Modelos> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Ordenes_Clientes_Detalles_Modelos
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetOrdenesClientesDetallesModelos = await _UnitOfWork.context.Ordenes_Clientes_Detalles_Modelos.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOrdenesClientesDetallesModelos
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

        // GET: api/Ordenes_Clientes_Detalles_Modelos/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetOrdenesClientesDetallesModelos = await _UnitOfWork.context.Ordenes_Clientes_Detalles_Modelos.Where(x => x.Orden_Cliente_Detalle_ModeloID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOrdenesClientesDetallesModelos
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
        public async Task<IActionResult> registrar([FromBody] Ordenes_Clientes_Detalles_Modelos ordenes_Clientes_Detalles_Modelos)
        {
            try
            {


                await _GenericRepository.Add(ordenes_Clientes_Detalles_Modelos);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Orden del Cliente Detalle Modelos se registro correctamente",
                    data = ordenes_Clientes_Detalles_Modelos
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Orden del Cliente Detalle Modelos no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Ordenes_Clientes_Detalles_Modelos/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Ordenes_Clientes_Detalles_Modelos ordenes_Clientes_Detalles_Modelos)
        {
            try
            {

                await _GenericRepository.Update(ordenes_Clientes_Detalles_Modelos);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = ordenes_Clientes_Detalles_Modelos

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