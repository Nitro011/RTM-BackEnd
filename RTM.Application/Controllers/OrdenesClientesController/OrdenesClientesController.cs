﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RTM.Models;
using RTM.Models.DTO.Orden_Cliente;
using RTM.Models.DTO.OrdenesClientes;
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

        // GET: api/OrdenesClientes/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> BuscarOrdenClienteId(int id)
        {
            try
            {

                var GetOrdenesClientes = await OrdenCliente(id);

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

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> OrdenesClientesList()
        {
            try
            {

                var GetOrdenesClientes = await OrdenesClientesListViews();

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

        [HttpGet]
        [Route("[action]/{Codigo}")]
        public async Task<IActionResult> ConsultarOrdenesClientesPorCodigo([FromRoute]string Codigo)
        {
            try
            {
                var GetOrdenesClientes = await BuscarOrdenesClientesPorCodigo(Codigo);

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
                    message = "La Orden del Cliente se registro correctamente"

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
                Ordenes_Clientes_Detalles = _UnitOfWork.context.Ordenes_Clientes_Detalles.Include(q => q.Marca).Where(d => d.Orden_ClienteID == s.Orden_ClienteID).Select(r => new OrdenesClientesDetalles()
                {

                    Orden_Cliente_DetalleID = r.Orden_Cliente_DetalleID,
                    Orden_ClienteID = s.Orden_ClienteID,
                    MarcaID = r.MarcaID,
                    Marcar = (r.Marca != null) ? r.Marca.Marca1 : ""


                }).FirstOrDefault()

            }).FirstOrDefaultAsync();

            orderncliente.Ordenes_Clientes_Detalles.Ordenes_Clientes_Detalles_Colores = _UnitOfWork.context.Ordenes_Clientes_Detalles_Colores.Where(g => g.Orden_Cliente_DetalleID == orderncliente.Ordenes_Clientes_Detalles.Orden_Cliente_DetalleID).Select(e => new DetallesColores()
            {
                Orden_Cliente_DetalleID = e.Orden_Cliente_DetalleID,
                Orden_Cliente_Detalle_ColorID = e.Orden_Cliente_Detalle_ColorID,
                ColorID = e.ColorID,
                Color = (e.Colore != null) ? e.Colore.Color : ""

            }).ToList();

            orderncliente.Ordenes_Clientes_Detalles.Ordenes_Clientes_Detalles_Size = _UnitOfWork.context.Ordenes_Clientes_Detalles_Dimensiones
                .Include(d => d.Size)
                .Include(d => d.Size.CategoriaSize)
                .Where(a => a.Orden_Cliente_DetalleID == orderncliente.Ordenes_Clientes_Detalles.Orden_Cliente_DetalleID).Select(x => new DetallesDimension()
                {
                    Orden_Cliente_Detalle_DimensionID = x.Orden_Cliente_Detalle_DimensionID,
                    Orden_Cliente_DetalleID = x.Orden_Cliente_DetalleID,
                    SizeID = x.SizeID,
                    USA = (x.Size != null) ? x.Size.USA : "",
                    UK = (x.Size != null) ? x.Size.UK : "",
                    CM = (x.Size != null) ? x.Size.CM : "",
                    EURO = (x.Size != null) ? x.Size.EURO : "",
                    CategoriaSize = (x.Size.CategoriaSize != null) ? x.Size.CategoriaSize.Clasificaciones : ""

                }).ToList();

            orderncliente.Ordenes_Clientes_Detalles.Ordenes_Clientes_Detalles_Modelos = _UnitOfWork.context.Ordenes_Clientes_Detalles_Modelos.Include(w => w.Modelo).Where(t => t.Orden_Cliente_DetalleID == orderncliente.Ordenes_Clientes_Detalles.Orden_Cliente_DetalleID).Select(q => new DetallesModelos()
            {
                Orden_Cliente_Detalle_ModeloID = q.Orden_Cliente_Detalle_ModeloID,
                Orden_Cliente_DetalleID = q.Orden_Cliente_DetalleID,
                ModeloID = q.ModeloID,
                Modelo = (q.Modelo != null) ? q.Modelo.Modelo1 : ""

            }).ToList();

            orderncliente.Ordenes_Clientes_Detalles.Ordenes_Clientes_Detalles_Tipos_Calzados = _UnitOfWork.context.Ordenes_Clientes_Detalles_Tipos_Calzados.Include(p => p.Tipo_Calzados).Where(g => g.Orden_Cliente_DetalleID == orderncliente.Ordenes_Clientes_Detalles.Orden_Cliente_DetalleID).Select(b => new DetallesCalzado()
            {
                Orden_Cliente_Detalle_Tipo_CalzadoID = b.Orden_Cliente_Detalle_Tipo_CalzadoID,
                Orden_Cliente_DetalleID = b.Orden_Cliente_DetalleID,
                Tipo_CalzadoID = b.Tipo_CalzadoID,
                Calzado = (b.Tipo_Calzados != null) ? b.Tipo_Calzados.Tipo_Calzado : ""

            }).ToList();

            return orderncliente;
        }

        private async Task<List<OrdenesClientesListView>> OrdenesClientesListViews()
        {

            var OrdenesClientesList = new List<OrdenesClientesListView>();


            OrdenesClientesList = await _UnitOfWork.context.Ordenes_Clientes.Select(a => new OrdenesClientesListView()
            {
                Orden_ClienteID=a.Orden_ClienteID,
                CodigoQR=a.CodigoQR,
                Cliente=_UnitOfWork.context.Ordenes_Clientes.Include(x=>x.Cliente).Where(x=>x.ClienteID==a.ClienteID).Select(a=>a.Cliente.Nombre_Cliente).FirstOrDefault(),
                CantidadCalzados=a.Cantidad_Calzado_Realizar,
                FechaInicio=a.Fecha_Inicio,
                FechaEntrega=a.Fecha_Entrega,
                Estilos=_UnitOfWork.context.OrdenesClientes_Estilos.Include(x=>x.Estilos).Where(x=>x.Orden_ClienteID==a.Orden_ClienteID).Select(a=>a.Estilos.Estilo_No).ToList(),
                SizesUSA=_UnitOfWork.context.OrdenesClientes_Sizes.Include(x=>x.Sizes).Where(x=>x.Orden_ClienteID==a.Orden_ClienteID).Select(a=>a.Sizes.USA).FirstOrDefault(),
                SizesUK = _UnitOfWork.context.OrdenesClientes_Sizes.Include(x => x.Sizes).Where(x => x.Orden_ClienteID == a.Orden_ClienteID).Select(a => a.Sizes.UK).FirstOrDefault(),
                SizesEuro = _UnitOfWork.context.OrdenesClientes_Sizes.Include(x => x.Sizes).Where(x => x.Orden_ClienteID == a.Orden_ClienteID).Select(a => a.Sizes.EURO).FirstOrDefault(),
                SizesCM = _UnitOfWork.context.OrdenesClientes_Sizes.Include(x => x.Sizes).Where(x => x.Orden_ClienteID == a.Orden_ClienteID).Select(a => a.Sizes.CM).FirstOrDefault(),


            }).ToListAsync();

            return OrdenesClientesList;

        }

        private async Task<List<OrdenesClientesListView>> BuscarOrdenesClientesPorCodigo(string Codigo)
        {
            var OrdenesClientesList = new List<OrdenesClientesListView>();

            OrdenesClientesList = await _UnitOfWork.context.Ordenes_Clientes
           .Where(a => a.CodigoQR == Codigo)
           .Select(a => new OrdenesClientesListView()
           {
               Orden_ClienteID = a.Orden_ClienteID,
               CodigoQR = a.CodigoQR,
               Cliente = _UnitOfWork.context.Ordenes_Clientes.Include(x => x.Cliente).Where(x => x.ClienteID == a.ClienteID).Select(a => a.Cliente.Nombre_Cliente).FirstOrDefault(),
               CantidadCalzados = a.Cantidad_Calzado_Realizar,
               FechaInicio = a.Fecha_Inicio,
               FechaEntrega = a.Fecha_Entrega,
               Estilos = _UnitOfWork.context.OrdenesClientes_Estilos.Include(x => x.Estilos).Where(x => x.Orden_ClienteID == a.Orden_ClienteID).Select(a => a.Estilos.Estilo_No).ToList(),
               SizesUSA = _UnitOfWork.context.OrdenesClientes_Sizes.Include(x => x.Sizes).Where(x => x.Orden_ClienteID == a.Orden_ClienteID).Select(a => a.Sizes.USA).FirstOrDefault(),
               SizesUK = _UnitOfWork.context.OrdenesClientes_Sizes.Include(x => x.Sizes).Where(x => x.Orden_ClienteID == a.Orden_ClienteID).Select(a => a.Sizes.UK).FirstOrDefault(),
               SizesEuro = _UnitOfWork.context.OrdenesClientes_Sizes.Include(x => x.Sizes).Where(x => x.Orden_ClienteID == a.Orden_ClienteID).Select(a => a.Sizes.EURO).FirstOrDefault(),
               SizesCM = _UnitOfWork.context.OrdenesClientes_Sizes.Include(x => x.Sizes).Where(x => x.Orden_ClienteID == a.Orden_ClienteID).Select(a => a.Sizes.CM).FirstOrDefault(),

           }).ToListAsync();

            return OrdenesClientesList;
        }
    }
}