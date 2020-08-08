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

namespace RTM.Application.Controllers.CategoriasEstilosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasEstiloController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<CategoriasEstilos> _GenericRepository;

        public CategoriasEstiloController(IUnitOfWork UnitOfWork, IGenericRepository<CategoriasEstilos> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Categorias Estilos
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetCategoriasEstilos = await _UnitOfWork.context.CategoriasEstilos.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetCategoriasEstilos
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

        // GET: api/CategoriasEstilos/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetCategoriasEstilos = await _UnitOfWork.context.CategoriasEstilos.Where(x => x.CategoriaEstiloID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetCategoriasEstilos
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
        public async Task<IActionResult> registrar([FromBody] CategoriasEstilos categoriasEstilos)
        {
            try
            {


                await _GenericRepository.Add(categoriasEstilos);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Categoria del Estilo se registro correctamente",
                    data = categoriasEstilos
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Categoria del Estilo no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Categorias Estilos/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] CategoriasEstilos categoriasEstilos)
        {
            try
            {

                await _GenericRepository.Update(categoriasEstilos);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = categoriasEstilos

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