using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.MateriasPrimas;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.MateriasPrimasController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasPrimasController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Materias_Primas> _GenericRepository;

        public MateriasPrimasController(IUnitOfWork UnitOfWork, IGenericRepository<Materias_Primas> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Materias Primas
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetMateriasPrimas = await _UnitOfWork.context.Materias_Primas.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetMateriasPrimas
                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = true,
                    message = "Ocurrio un error inesperado!!",
                    data = ex.Message
                });
            }



        }

        // GET: api/MateriasPrimas/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetMateriasPrimas = await _UnitOfWork.context.Materias_Primas.Where(x => x.Materia_PrimaID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetMateriasPrimas
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
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> MateriasPrimasList()
        {
            try
            {

                var GetMateriasPrimas = await MateriasPrimasListViews();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetMateriasPrimas
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
        [Route("[action]/{PartNo}/{MateriaPrima}")]
        public async Task<IActionResult> ConsultarMateriasPrimasPorPartNoMateriaPrima([FromRoute]string PartNo, string MateriaPrima)
        {
            try
            {
                var GetMateriasPrimas = await MateriasPrimasPorPartNoMateriasPrimas(PartNo,MateriaPrima);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetMateriasPrimas
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
        public async Task<IActionResult> registrar([FromBody] Materias_Primas materias_Primas)
        {
            try
            {


                await _GenericRepository.Add(materias_Primas);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Materia Prima se registro correctamente",
                    data = materias_Primas
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Materia Prima no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Materias Primas/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Materias_Primas materias_Primas)
        {
            try
            {

                await _GenericRepository.Update(materias_Primas);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = materias_Primas

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
        private async Task<List<MateriasPrimasListView>> MateriasPrimasListViews()
        {

            var MateriasPrimasList = new List<MateriasPrimasListView>();


            MateriasPrimasList = await _UnitOfWork.context.Materias_Primas.Select(a => new MateriasPrimasListView()
            {
                Materia_PrimaID = a.Materia_PrimaID,
                PartNo = a.PartNo,
                TipoMaterial = _UnitOfWork.context.Materias_Primas.Include(x => x.Tipo_Material).Where(x => x.Materia_PrimaID == a.Materia_PrimaID).Select(a => a.Tipo_Material.Nombre_Material).FirstOrDefault(),
                Descripcion = a.Descripcion,
                Cost = a.Cost,
                Unit = a.Unit

            }).ToListAsync();

            return MateriasPrimasList;

        }

        //Consultar Materias Primas por PartNo y Nombre de la Materia Prima:
        private async Task<List<MateriasPrimasListView>> MateriasPrimasPorPartNoMateriasPrimas(string PartNo, string MateriaPrima)
        {
            var MateriasPrimasList = new List<MateriasPrimasListView>();

                 MateriasPrimasList = await _UnitOfWork.context.Materias_Primas
                .Where(a => a.PartNo==PartNo || a.Descripcion==MateriaPrima)
                .Select(a => new MateriasPrimasListView()
                {
                    Materia_PrimaID=a.Materia_PrimaID,
                    PartNo=a.PartNo,
                    TipoMaterial = _UnitOfWork.context.Materias_Primas.Include(x => x.Tipo_Material).Where(x => x.Materia_PrimaID == a.Materia_PrimaID).Select(a => a.Tipo_Material.Nombre_Material).FirstOrDefault(),
                    Descripcion = a.Descripcion,
                    Cost=a.Cost,
                    Unit=a.Unit

                }).ToListAsync();

            return MateriasPrimasList;
        }
    }
}