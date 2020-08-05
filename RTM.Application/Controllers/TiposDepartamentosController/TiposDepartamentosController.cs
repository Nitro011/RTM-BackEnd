using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.TiposDepartamentos;
using RTM.Models.TableDB;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.TiposDepartamentosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDepartamentosController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<TiposDepartamentos> _GenericRepository;

        public TiposDepartamentosController(IUnitOfWork UnitOfWork, IGenericRepository<TiposDepartamentos> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/TiposDepartamentos
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetTiposDepartamentos = await _UnitOfWork.context.TiposDepartamentos.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetTiposDepartamentos
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

        // GET: api/TiposDepartamentos/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetTiposDepartamentos = await _UnitOfWork.context.TiposDepartamentos.Where(x => x.TipoDepartamentoID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetTiposDepartamentos
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

        [HttpGet]
        [Route("[action]/{TipoDepartamento}")]
        public async Task<IActionResult> ConsultarTiposDepartamentosPorTipoDepartamento([FromRoute]string TipoDepartamento)
        {
            try
            {
                var GetTiposDepartamentos = await BuscarTiposDepartamentosPorTipoDepartamento(TipoDepartamento);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetTiposDepartamentos
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
        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> DepartamentosList()
        //{
        //    try
        //    {

        //        var GetDepartamentos = await DepartamentosListViews();

        //        return Ok(new Request()
        //        {
        //            status = true,
        //            message = "Esta accion se ejecuto correctamente",
        //            data = GetDepartamentos
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
        public async Task<IActionResult> registrar([FromBody] TiposDepartamentos tiposDepartamentos)
        {
            try
            {


                await _GenericRepository.Add(tiposDepartamentos);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Tipo de Departamento se registro correctamente",
                    data = tiposDepartamentos
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Tipo de Departamento no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/TiposDepartamentos/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] TiposDepartamentos tiposDepartamentos)
        {
            try
            {

                await _GenericRepository.Update(tiposDepartamentos);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = tiposDepartamentos

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
        private async Task<List<TiposDepartamentosListView>> BuscarTiposDepartamentosPorTipoDepartamento(string TipoDepartamento)
        {
            var TiposDepartamentosList = new List<TiposDepartamentosListView>();

            TiposDepartamentosList = await _UnitOfWork.context.TiposDepartamentos
           .Where(a => a.TipoDepartamento == TipoDepartamento)
           .Select(a => new TiposDepartamentosListView()
           {
               TipoDepartamentoID = a.TipoDepartamentoID,
               TipoDepartamento=a.TipoDepartamento,

           }).ToListAsync();

            return TiposDepartamentosList;
        }
    }
}