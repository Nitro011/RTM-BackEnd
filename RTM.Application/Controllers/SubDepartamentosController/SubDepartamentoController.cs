using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models.TableDB;
using RTM.Repository.Interface;
using RTM.Models;
using RTM.Models.DTO.SubDepartamentos;
using RTM.Models.DTO.Posiciones;

namespace RTM.Application.Controllers.SubDepartamentosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDepartamentoController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<SubDepartamentos> _GenericRepository;

        public SubDepartamentoController(IUnitOfWork UnitOfWork, IGenericRepository<SubDepartamentos> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/SubDepartamentos
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetSubDepartamentos = await _UnitOfWork.context.SubDepartamentos.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSubDepartamentos
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

        // GET: api/SubDepartamentos/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetSubDepartamentos = await _UnitOfWork.context.SubDepartamentos.Where(x => x.SubDepartamentoID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSubDepartamentos
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
        public async Task<IActionResult> SubDepartamentosList()
        {
            try
            {

                var GetSubDepartamentos = await SubDepartamentosListViews();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSubDepartamentos
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
        [Route("[action]/{SubDepartamento}/{Departamento}")]
        public async Task<IActionResult> BuscarDepartamentosPorDepartamento([FromRoute]string SubDepartamento, string Departamento)
        {
            try
            {
                var GetSubDepartamentos = await SubDepartamentosPorDepartamentoSubDepartamento(SubDepartamento,Departamento);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSubDepartamentos
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
        public async Task<IActionResult> registrar([FromBody] SubDepartamentos subDepartamentos)
        {
            try
            {


                await _GenericRepository.Add(subDepartamentos);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El SubDepartamento se registro correctamente",
                    data = subDepartamentos
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El SubDepartamento no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/SubDepartamentos/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] SubDepartamentos subDepartamentos)
        {
            try
            {

                await _GenericRepository.Update(subDepartamentos);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = subDepartamentos

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

        private async Task<List<SubDepartamentosListView>> SubDepartamentosListViews()
        {

            var SubDepartamentosList = new List<SubDepartamentosListView>();


            SubDepartamentosList = await _UnitOfWork.context.SubDepartamentos.Select(a => new SubDepartamentosListView()
            {
                SubDepartamentoID=a.SubDepartamentoID,
                DepartamentoID=a.DepartamentoID,
                Departamento = _UnitOfWork.context.SubDepartamentos.Include(x => x.Departamentos).Where(x => x.DepartamentoID == a.DepartamentoID).Select(a => a.Departamentos.Departamento).FirstOrDefault(),
                SubDepartamento = _UnitOfWork.context.SubDepartamentos.Where(x => x.SubDepartamentoID == a.SubDepartamentoID).Select(a => a.SubDepartamento).FirstOrDefault()

            }).ToListAsync();

            return SubDepartamentosList;

        }

        private async Task<List<SubDepartamentosListView>> SubDepartamentosPorDepartamentoSubDepartamento(string SubDepartamento, string Departamento)
        {
            var SubDepartamentosList = new List<SubDepartamentosListView>();

            SubDepartamentosList = await _UnitOfWork.context.SubDepartamentos
           .Where(a => a.SubDepartamento==SubDepartamento || a.Departamentos.Departamento == Departamento )
           .Select(a => new SubDepartamentosListView()
           {
               SubDepartamentoID = a.SubDepartamentoID,
               DepartamentoID = a.DepartamentoID,
               Departamento = _UnitOfWork.context.SubDepartamentos.Include(x => x.Departamentos).Where(x => x.DepartamentoID == a.DepartamentoID).Select(a => a.Departamentos.Departamento).FirstOrDefault(),
               SubDepartamento = _UnitOfWork.context.SubDepartamentos.Where(x => x.SubDepartamentoID == a.SubDepartamentoID).Select(a => a.SubDepartamento).FirstOrDefault()

           }).ToListAsync();

            return SubDepartamentosList;
        }
    }
}