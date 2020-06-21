using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RTM.Models;
using RTM.Models.DTO.Orden_Cliente;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.OrdenesClientesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesClientesController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Ordenes_Clientes> _GenericRepository;

        public OrdenesClientesController(IUnitOfWork UnitOfWork, IGenericRepository<Ordenes_Clientes> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Ordenes_Clientes
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetOrdenesClientes = await _UnitOfWork.context.Ordenes_Clientes.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOrdenesClientes
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

        // GET: api/OrdenesClientes/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetOrdenesClientes = await _UnitOfWork.context.Ordenes_Clientes.Where(x => x.Orden_ClienteID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetOrdenesClientes
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
        public async Task<IActionResult> registrar([FromBody] Ordenes_Clientes ordenes_Clientes)
        {
            try
            {


                await _GenericRepository.Add(ordenes_Clientes);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Orden del Cliente se registro correctamente",
                    data = ordenes_Clientes
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Orden del Cliente no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Ordenes_Clientes/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Ordenes_Clientes ordenes_Clientes)
        {
            try
            {

                await _GenericRepository.Update(ordenes_Clientes);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = ordenes_Clientes

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


        public async Task<OrdenCliente> OrdenCliente(int id)
        {
            var orderncliente = new OrdenCliente();

            orderncliente = await _UnitOfWork.context.Ordenes_Clientes.Include(s => s.Cliente).Where(x => x.ClienteID == id).Select(s => new OrdenCliente()
            {

                Orden_ClienteID = s.Orden_ClienteID,
                ClienteID = s.ClienteID,
                Cantidad_Calzado_Realizar = s.Cantidad_Calzado_Realizar,
                CodigoQR = s.CodigoQR,
                NombreCliente = (s.Cliente != null) ? $"{s.Cliente.Nombre_Cliente}" : "",
                Fecha_Entrega = s.Fecha_Entrega,
                Fecha_Inicio = s.Fecha_Inicio,
                Ordenes_Clientes_Detalles =  _UnitOfWork.context.Ordenes_Clientes_Detalles.Include(q => q.Marca).Where(d => d.Orden_ClienteID == s.Orden_ClienteID).Select(r => new OrdenesClientesDetalles()
                {

                    Orden_Cliente_DetalleID = r.Orden_Cliente_DetalleID,
                    Orden_ClienteID = s.Orden_ClienteID,
                    MarcaID = r.MarcaID,
                    Marcar = (r.Marca != null) ? r.Marca.Marca1 : "",

                    Ordenes_Clientes_Detalles_Colores = _UnitOfWork.context.Ordenes_Clientes_Detalles_Colores.Include(a => a.Colore).Where(g => g.Orden_Cliente_DetalleID == r.Orden_Cliente_DetalleID).Select(e => new DetallesColores()
                    {
                        Orden_Cliente_DetalleID = r.Orden_Cliente_DetalleID,
                        Orden_Cliente_Detalle_ColorID = e.Orden_Cliente_Detalle_ColorID,
                        ColorID = e.ColorID,
                        Color = (e.Colore != null) ? e.Colore.Color : ""

                    }).ToList(),
                    Ordenes_Clientes_Detalles_Dimensiones = _UnitOfWork.context.Ordenes_Clientes_Detalles_Dimensiones.Include(d => d.Dimensione).Where(a => a.Orden_Cliente_DetalleID == r.Orden_Cliente_DetalleID).Select(x => new DetallesDimension()
                    {
                        Orden_Cliente_Detalle_DimensionID = x.Orden_Cliente_Detalle_DimensionID,
                        Orden_Cliente_DetalleID = r.Orden_Cliente_DetalleID,
                        DimensionID = x.DimensionID,
                        Longitud = (x.Dimensione != null) ? x.Dimensione.Longitud : 0,
                        Anchura = (x.Dimensione != null) ? x.Dimensione.Anchura : 0,
                        Altura = (x.Dimensione != null) ? x.Dimensione.Altura : 0


                    }).ToList(),
                    Ordenes_Clientes_Detalles_Modelos = _UnitOfWork.context.Ordenes_Clientes_Detalles_Modelos.Include(w => w.Modelo).Where(t => t.Orden_Cliente_DetalleID == r.Orden_Cliente_DetalleID).Select(q => new DetallesModelos()
                    {
                        Orden_Cliente_Detalle_ModeloID = q.Orden_Cliente_Detalle_ModeloID,
                        Orden_Cliente_DetalleID = r.Orden_Cliente_DetalleID,
                        ModeloID = q.ModeloID,
                        Modelo = (q.Modelo != null) ? q.Modelo.Modelo1 : ""

                    }).ToList(),
                    Ordenes_Clientes_Detalles_Tipos_Calzados = _UnitOfWork.context.Ordenes_Clientes_Detalles_Tipos_Calzados.Include(p => p.Tipo_Calzados).Where(g => g.Orden_Cliente_DetalleID == r.Orden_Cliente_DetalleID).Select(b => new DetallesCalzado()
                    {
                        Orden_Cliente_Detalle_Tipo_CalzadoID = b.Orden_Cliente_Detalle_Tipo_CalzadoID,
                        Orden_Cliente_DetalleID = r.Orden_Cliente_DetalleID,
                        Tipo_CalzadoID = b.Tipo_CalzadoID,
                        Calzado = (b.Tipo_Calzados != null) ? b.Tipo_Calzados.Tipo_Calzado : ""

                    }).ToList()

                }).FirstOrDefault()

            }).FirstOrDefaultAsync();

            return orderncliente;
        }
    }
}