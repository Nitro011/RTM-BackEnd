using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.TableDB;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.BOMDetallesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BOMDetalleController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<BOMDetalles> _GenericRepository;

        public BOMDetalleController(IUnitOfWork UnitOfWork, IGenericRepository<BOMDetalles> GenericRepository)
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

                var GetBOMSDetalles = await _UnitOfWork.context.BOMDetalles.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetBOMSDetalles
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

        // GET: api/BOMSDetalles/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetBOMSDetalles = await _UnitOfWork.context.BOMDetalles.Where(x => x.BOMDetalleID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetBOMSDetalles
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


        // GET: api/BOMSDetalles
        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> BOMSDetallesList()
        //{
        //    try
        //    {

        //        var GetBOMSDetalles = await BOMSDetallesListViews();

        //        return Ok(new Request()
        //        {
        //            status = true,
        //            message = "Esta accion se ejecuto correctamente",
        //            data = GetBOMSDetalles
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

        //[HttpGet]
        //[Route("[action]/{PatterN}/{Cliente}")]
        //public async Task<IActionResult> ConsultarBOMDetallesPorPatterNCliente([FromRoute]string PatterN, string Cliente)
        //{
        //    try
        //    {
        //        var GetBOMEncabezado = await BOMEncabezadoPorPatterNCliente(PatterN, Cliente);

        //        return Ok(new Request()
        //        {
        //            status = true,
        //            message = "Esta accion se ejecuto correctamente",
        //            data = GetBOMEncabezado
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
        public async Task<IActionResult> registrar([FromBody] BOMDetalles bOMDetalles)
        {
            try
            {


                await _GenericRepository.Add(bOMDetalles);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Detalle del BOM se registro correctamente",
                    data = bOMDetalles
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Detalle del BOM no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/BOMSDetalles/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] BOMDetalles bOMDetalles)
        {
            try
            {

                await _GenericRepository.Update(bOMDetalles);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = bOMDetalles

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