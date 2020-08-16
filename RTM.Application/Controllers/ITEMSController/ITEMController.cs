using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.ITEMS;
using RTM.Models.TableDB;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.ITEMSController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITEMController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<ITEMS> _GenericRepository;

        public ITEMController(IUnitOfWork UnitOfWork, IGenericRepository<ITEMS> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/ITEMS
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetITEMS = await _UnitOfWork.context.ITEMS.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetITEMS
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

        // GET: api/ITEMS/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetITEMS = await _UnitOfWork.context.ITEMS.Where(x => x.ITEMID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetITEMS
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

        // GET: api/Empleados
        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> MateriasPrimasList()
        //{
        //    try
        //    {

        //        var GetMateriasPrimas = await MateriasPrimasListViews();

        //        return Ok(new Request()
        //        {
        //            status = true,
        //            message = "Esta accion se ejecuto correctamente",
        //            data = GetMateriasPrimas
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

        [HttpGet]
        [Route("[action]/{ITEM}")]
        public async Task<IActionResult> ConsultarITEMSPorITEM([FromRoute]string ITEM)
        {
            try
            {
                var GetITEMS = await ITEMSPorITEM(ITEM);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetITEMS
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
        public async Task<IActionResult> registrar([FromBody] ITEMS iTEMS)
        {
            try
            {


                await _GenericRepository.Add(iTEMS);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Item se registro correctamente",
                    data = iTEMS
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Item no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Materias Primas/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] ITEMS iTEMS)
        {
            try
            {

                await _GenericRepository.Update(iTEMS);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = iTEMS

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
        //private async Task<List<DivisionesMateriasPrimasListView>> MateriasPrimasListViews()
        //{

        //    var MateriasPrimasList = new List<DivisionesMateriasPrimasListView>();


        //    MateriasPrimasList = await _UnitOfWork.context.DivisionesMateriasPrimas.Select(a => new DivisionesMateriasPrimasListView()
        //    {
        //        Division,
        //        PartNo = a.PartNo,
        //        Nombre_Materia_Prima = a.Descripcion,
        //        TipoMaterial = _UnitOfWork.context.Materias_Primas.Include(x => x.Tipo_Material).Where(x => x.Materia_PrimaID == a.Materia_PrimaID).Select(a => a.Tipo_Material.Nombre_Material).FirstOrDefault(),
        //        Descripcion = a.Descripcion

        //    }).ToListAsync();

        //    return MateriasPrimasList;

        //}

        //Consultar Materias Primas por PartNo y Nombre de la Materia Prima:
        private async Task<List<ITEMSListView>> ITEMSPorITEM(string ITEM)
        {
            var ITEMSList = new List<ITEMSListView>();

            ITEMSList = await _UnitOfWork.context.ITEMS
           .Where(a => a.nombreITEMS == ITEM)
           .Select(a => new ITEMSListView()
           {
               ITEMID=a.ITEMID,
               nombreITEMS=a.nombreITEMS,

           }).ToListAsync();

            return ITEMSList;
        }
    }
}