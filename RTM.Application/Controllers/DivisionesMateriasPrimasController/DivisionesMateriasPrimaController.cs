using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.DivisionesMateriasPrimas;
using RTM.Models.TableDB;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.DivisionesMateriasPrimasController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionesMateriasPrimaController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<DivisionesMateriasPrimas> _GenericRepository;

        public DivisionesMateriasPrimaController(IUnitOfWork UnitOfWork, IGenericRepository<DivisionesMateriasPrimas> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Divisiones Materias Primas
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetDivisionesMateriasPrimas = await _UnitOfWork.context.DivisionesMateriasPrimas.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetDivisionesMateriasPrimas
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

        // GET: api/DivisionesMateriasPrimas/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetDivisionesMateriasPrimas = await _UnitOfWork.context.DivisionesMateriasPrimas.Where(x => x.DivisionMateriaPrimaID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetDivisionesMateriasPrimas
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
        [Route("[action]/{Divisiones}")]
        public async Task<IActionResult> ConsultarDivisionesMateriasPrimasPorDivisiones([FromRoute]string Divisiones)
        {
            try
            {
                var GetDivisionesMateriasPrimas = await DivisionesMateriasPrimasPorDivisiones(Divisiones);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetDivisionesMateriasPrimas
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
        public async Task<IActionResult> registrar([FromBody] DivisionesMateriasPrimas divisionesMateriasPrimas)
        {
            try
            {


                await _GenericRepository.Add(divisionesMateriasPrimas);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Division de la Materia Prima se registro correctamente",
                    data = divisionesMateriasPrimas
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Division de la  Materia Prima no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Materias Primas/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] DivisionesMateriasPrimas divisionesMateriasPrimas) 
        {
            try
            {

                await _GenericRepository.Update(divisionesMateriasPrimas);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = divisionesMateriasPrimas

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
        private async Task<List<DivisionesMateriasPrimasListView>> DivisionesMateriasPrimasPorDivisiones(string Divisiones)
        {
            var DivisionesMateriasPrimasList = new List<DivisionesMateriasPrimasListView>();

            DivisionesMateriasPrimasList = await _UnitOfWork.context.DivisionesMateriasPrimas
           .Where(a => a.Division== Divisiones)
           .Select(a => new DivisionesMateriasPrimasListView()
           {
               DivisionMateriaPrimaID=a.DivisionMateriaPrimaID,
               Division=a.Division

           }).ToListAsync();

            return DivisionesMateriasPrimasList;
        }
    }
}