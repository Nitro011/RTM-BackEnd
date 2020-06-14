using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.OrdenesClientesDetallesColoresController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesClientesDetallesColoresController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Ordenes_Clientes_Detalles_Colores> _GenericRepository;

        public OrdenesClientesDetallesColoresController(IUnitOfWork UnitOfWork, IGenericRepository<Ordenes_Clientes_Detalles_Colores> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Ordenes_Clientes_Detalles_Colores
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetOrdenesClientesDetallesColores = await _UnitOfWork.context.Ordenes_Clientes_Detalles_Colores.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOrdenesClientesDetallesColores
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

        // GET: api/Ordenes_Clientes_Detalles_Colores/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetOrdenesClientesDetallesColores = await _UnitOfWork.context.Ordenes_Clientes_Detalles_Colores.Where(x => x.Orden_Cliente_Detalle_ColorID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOrdenesClientesDetallesColores
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
        public async Task<IActionResult> registrar([FromBody] Ordenes_Clientes_Detalles_Colores ordenes_Clientes_Detalles_Colores)
        {
            try
            {


                await _GenericRepository.Add(ordenes_Clientes_Detalles_Colores);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Orden del Cliente Detalle Color se registro correctamente",
                    data = ordenes_Clientes_Detalles_Colores
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Orden del Cliente Detalle Color no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Ordenes_Clientes_Detalles_Colores/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Ordenes_Clientes_Detalles_Colores ordenes_Clientes_Detalles_Colores)
        {
            try
            {

                await _GenericRepository.Update(ordenes_Clientes_Detalles_Colores);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = ordenes_Clientes_Detalles_Colores

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