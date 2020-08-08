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

namespace RTM.Application.Controllers.PesosEstilosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesosEstilosController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<PesosEstilos> _GenericRepository;

        public PesosEstilosController(IUnitOfWork UnitOfWork, IGenericRepository<PesosEstilos> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/PesosEstilos
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetPesosEstilos = await _UnitOfWork.context.PesosEstilos.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetPesosEstilos
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

        // GET: api/PesosEstilos/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetPesosEstilos = await _UnitOfWork.context.PesosEstilos.Where(x => x.PesoEstiloID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetPesosEstilos
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
        public async Task<IActionResult> registrar([FromBody] PesosEstilos pesosEstilos)
        {
            try
            {


                await _GenericRepository.Add(pesosEstilos);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Peso del Estilo se registro correctamente",
                    data = pesosEstilos
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Peso del Estilo no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/PesosEstilos/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] PesosEstilos pesosEstilos)
        {
            try
            {

                await _GenericRepository.Update(pesosEstilos);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = pesosEstilos

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