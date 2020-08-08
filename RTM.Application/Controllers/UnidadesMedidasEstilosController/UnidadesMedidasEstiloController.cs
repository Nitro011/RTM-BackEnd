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

namespace RTM.Application.Controllers.UnidadesMedidasEstilosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidasEstiloController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<UnidadesMedidasEstilos> _GenericRepository;

        public UnidadesMedidasEstiloController(IUnitOfWork UnitOfWork, IGenericRepository<UnidadesMedidasEstilos> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/UnidadesMedidasEstilos
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetUnidadesMedidasEstilos = await _UnitOfWork.context.UnidadesMedidasEstilos.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetUnidadesMedidasEstilos
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

        // GET: api/UnidadesMedidasEstilos/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetUnidadesMedidasEstilos = await _UnitOfWork.context.UnidadesMedidasEstilos.Where(x => x.UnidadMedidaEstiloID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetUnidadesMedidasEstilos
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

        // GET: api/Categorias Estilos
        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> CategoriasEstilosList()
        //{
        //    try
        //    {

        //        var GetCategoriasEstilos = await MateriasPrimasListViews();

        //        return Ok(new Request()
        //        {
        //            status = true,
        //            message = "Esta accion se ejecuto correctamente",
        //            data = GetCategoriasEstilos
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
        //[Route("[action]/{PartNo}/{MateriaPrima}")]
        //public async Task<IActionResult> ConsultarMateriasPrimasPorPartNoMateriaPrima([FromRoute]string PartNo, string MateriaPrima)
        //{
        //    try
        //    {
        //        var GetMateriasPrimas = await MateriasPrimasPorPartNoMateriasPrimas(PartNo, MateriaPrima);

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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> registrar([FromBody] UnidadesMedidasEstilos unidadesMedidasEstilos)
        {
            try
            {


                await _GenericRepository.Add(unidadesMedidasEstilos);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Unidad de Medida del Estilo se registro correctamente",
                    data = unidadesMedidasEstilos
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Unidad de Medida no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/UnidadesMedidasEstilos/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] UnidadesMedidasEstilos unidadesMedidasEstilos)
        {
            try
            {

                await _GenericRepository.Update(unidadesMedidasEstilos);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = unidadesMedidasEstilos

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