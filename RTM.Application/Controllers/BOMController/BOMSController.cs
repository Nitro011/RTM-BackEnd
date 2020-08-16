using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.BOMEncabezado;
using RTM.Models.TableDB;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.BOMController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BOMSController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<BOM> _GenericRepository;

        public BOMSController(IUnitOfWork UnitOfWork, IGenericRepository<BOM> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/BOMS
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetBOMS = await _UnitOfWork.context.BOMs.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetBOMS
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

        // GET: api/BOMS/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetBOMS = await _UnitOfWork.context.BOMs.Where(x => x.BOMID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetBOMS
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
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> BOMEncabezadosList()
        {
            try
            {

                var GetBOMEncabezado = await BOMEncabezadoListViews();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetBOMEncabezado
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
        [Route("[action]/{PatterN}/{Cliente}")]
        public async Task<IActionResult> ConsultarBOMEncabezadoPorPatterNCliente([FromRoute]string PatterN, string Cliente)
        {
            try
            {
                var GetBOMEncabezado = await BOMEncabezadoPorPatterNCliente(PatterN,Cliente);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetBOMEncabezado
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
        [Route("[action]/{PatterN}")]
        public async Task<IActionResult> BuscarBOMEncabezadoPorPatterNCliente([FromRoute]string PatterN)
        {
            try
            {
                var GetBOMEncabezado = await ObtenerBOMEncabezadoPorPatterNCliente(PatterN);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetBOMEncabezado
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
        public async Task<IActionResult> registrar([FromBody] BOM bOM)
        {
            try
            {


                await _GenericRepository.Add(bOM);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Encabezado del BOM se registro correctamente",
                    data = bOM
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Encabezado del BOM no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/BOM/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] BOM bOM)
        {
            try
            {

                await _GenericRepository.Update(bOM);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = bOM

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
        private async Task<List<BOMEncabezadoListView>> BOMEncabezadoListViews()
        {

            var BOMEncabezadoList = new List<BOMEncabezadoListView>();


            BOMEncabezadoList = await _UnitOfWork.context.BOMs.Select(a => new BOMEncabezadoListView()
            {
                BOMID=a.BOMID,
                FechaCreacion=a.FechaCreacion,
                PatterN=a.PatterN,
                Modelo=_UnitOfWork.context.BOMs.Include(x=>x.Modelos).Where(x=>x.ModeloID==a.ModeloID).Select(a=>a.Modelos.Modelo1).FirstOrDefault(),
                Cliente= _UnitOfWork.context.BOMs.Include(x => x.Cliente).Where(x => x.ClienteID == a.ClienteID).Select(a => a.Cliente.Nombre_Cliente).FirstOrDefault()

            }).ToListAsync();

            return BOMEncabezadoList;

        }

        private async Task<List<BOMEncabezadoListView>> BOMEncabezadoPorPatterNCliente(string PatterN, string Cliente)
        {
            var BOMEncabezadoList = new List<BOMEncabezadoListView>();

            BOMEncabezadoList = await _UnitOfWork.context.BOMs
           .Where(a => a.PatterN==PatterN || a.Cliente.Nombre_Cliente==Cliente)
           .Select(a => new BOMEncabezadoListView()
           {
               BOMID = a.BOMID,
               FechaCreacion=a.FechaCreacion,
               PatterN = a.PatterN,
               Modelo = _UnitOfWork.context.BOMs.Include(x => x.Modelos).Where(x => x.ModeloID == a.ModeloID).Select(a => a.Modelos.Modelo1).FirstOrDefault(),
               Cliente = _UnitOfWork.context.BOMs.Include(x => x.Cliente).Where(x => x.ClienteID == a.ClienteID).Select(a => a.Cliente.Nombre_Cliente).FirstOrDefault()

           }).ToListAsync();

            return BOMEncabezadoList;
        }

        private async Task<ObtenerBOMEncabezadoPorPatterNCliente> ObtenerBOMEncabezadoPorPatterNCliente(string PatterN)
        {
            var BOMEncabezadoList = new ObtenerBOMEncabezadoPorPatterNCliente();

            BOMEncabezadoList = await _UnitOfWork.context.BOMs
           .Where(a => a.PatterN == PatterN)
           .Select(a => new ObtenerBOMEncabezadoPorPatterNCliente()
           {
               BOMID = a.BOMID,
               PatterN = a.PatterN,
               Cliente= _UnitOfWork.context.BOMs.Include(x => x.Cliente).Where(x => x.ClienteID == a.ClienteID).Select(a => a.Cliente.Nombre_Cliente).FirstOrDefault()

           }).FirstOrDefaultAsync();

            return BOMEncabezadoList;
        }
    }
}