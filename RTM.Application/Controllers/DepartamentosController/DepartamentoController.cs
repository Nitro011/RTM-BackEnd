using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.Departamentos;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.DepartamentosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Departamentos> _GenericRepository;

        public DepartamentoController(IUnitOfWork UnitOfWork, IGenericRepository<Departamentos> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Departamentos
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetDepartamentos = await _UnitOfWork.context.Departamentos.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetDepartamentos
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

        // GET: api/Departamentos/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetDepartamentos = await _UnitOfWork.context.Departamentos.Where(x => x.DepartamentoID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetDepartamentos
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
        [Route("[action]/{Departamento}")]
        public async Task<IActionResult> BuscarDepartamentosPorDepartamento([FromRoute]string Departamento)
        {
            try
            {
                var GetDepartamentos = await DepartamentosPorDepartamento(Departamento);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetDepartamentos
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
        public async Task<IActionResult> DepartamentosList()
        {
            try
            {

                var GetDepartamentos = await DepartamentosListViews();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetDepartamentos
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
        [Route("[action]/{DepartamentoID}")]
        public async Task<IActionResult> ObtenerDepartamentoPorID([FromRoute]int DepartamentoID)
        {
            try
            {

                var GetDepartamentos = await DepartamentosPorID(DepartamentoID);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetDepartamentos
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
        public async Task<IActionResult> registrar([FromBody] Departamentos departamentos)
        {
            try
            {


                await _GenericRepository.Add(departamentos);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Departamento se registro correctamente",
                    data = departamentos
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Departamento no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Departamentos/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Departamentos departamentos)
        {
            try
            {

                await _GenericRepository.Update(departamentos);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = departamentos

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
        private async Task<List<DepartamentosListView>> DepartamentosPorDepartamento(string Departamento)
        {
            var DepartamentosList = new List<DepartamentosListView>();

            DepartamentosList = await _UnitOfWork.context.Departamentos
           .Where(a => a.Departamento == Departamento)
           .Select(a => new DepartamentosListView()
           {
               DepartamentoID=a.DepartamentoID,
               TipoDepartamentoID=a.TipoDepartamentoID,
               TipoDepartamento= _UnitOfWork.context.Departamentos.Include(x=>x.TiposDepartamentos).Where(x => x.TipoDepartamentoID == a.TipoDepartamentoID).Select(a => a.TiposDepartamentos.TipoDepartamento).FirstOrDefault(),
               Departamento =a.Departamento,
               SubDepartamento = _UnitOfWork.context.SubDepartamentos.Include(x => x.Departamentos).Where(x => x.DepartamentoID == a.DepartamentoID).Select(a => a.SubDepartamento).FirstOrDefault()
           }).ToListAsync();

            return DepartamentosList;
        }

        private async Task<List<DepartamentosListView>> DepartamentosListViews()
        {

            var DepartamentosList = new List<DepartamentosListView>();


            DepartamentosList = await _UnitOfWork.context.Departamentos.Select(a => new DepartamentosListView()
            {
                DepartamentoID = a.DepartamentoID,
                TipoDepartamentoID = a.TipoDepartamentoID,
                TipoDepartamento = _UnitOfWork.context.Departamentos.Include(x => x.TiposDepartamentos).Where(x => x.TipoDepartamentoID == a.TipoDepartamentoID).Select(a => a.TiposDepartamentos.TipoDepartamento).FirstOrDefault(),
                Departamento = a.Departamento,
                SubDepartamento = _UnitOfWork.context.SubDepartamentos.Where(x=>x.DepartamentoID==a.DepartamentoID).Select(a=>a.SubDepartamento).FirstOrDefault()

            }).ToListAsync();

            return DepartamentosList;

        }

        private async Task<DepartamentosListView> DepartamentosPorID(int DepartamentoID)
        {
            var DepartamentosList = new DepartamentosListView();

            DepartamentosList = await _UnitOfWork.context.Departamentos
           .Where(a => a.DepartamentoID == DepartamentoID)
           .Select(a => new DepartamentosListView()
           {
               DepartamentoID = a.DepartamentoID,
               TipoDepartamentoID = a.TipoDepartamentoID,
               TipoDepartamento = _UnitOfWork.context.Departamentos.Include(x => x.TiposDepartamentos).Where(x => x.TipoDepartamentoID == a.TipoDepartamentoID).Select(a => a.TiposDepartamentos.TipoDepartamento).FirstOrDefault(),
               Departamento = a.Departamento,
               SubDepartamento = _UnitOfWork.context.SubDepartamentos.Include(x => x.Departamentos).Where(x => x.DepartamentoID == a.DepartamentoID).Select(a => a.SubDepartamento).FirstOrDefault()
           }).FirstOrDefaultAsync();

            return DepartamentosList;
        }
    }
}