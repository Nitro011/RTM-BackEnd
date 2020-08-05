using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTM.Repository.Interface;
using RTM.Models;
using Microsoft.EntityFrameworkCore;
using RTM.Models.DTO.Suplidores;

namespace RTM.Application.Controllers.Suplidores
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuplidoresController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Suplidore> _GenericRepository;

        public SuplidoresController(IUnitOfWork UnitOfWork, IGenericRepository<Suplidore> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Suplidores
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetSuplidores = await _UnitOfWork.context.Suplidores.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSuplidores
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

        // GET: api/Empleados
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> SuplidorPorCodigo([FromRoute]int id)
        {
            try
            {

                var GetSuplidor = await SuplidoresCodigo(id);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSuplidor
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

        // GET: api/Suplidores
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SuplidoresList()
        {
            try
            {

                var GetSuplidores = await SuplidoresListViews();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSuplidores
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

        // GET: api/Suplidores/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetSuplidores = await _UnitOfWork.context.Suplidores.Where(x => x.SuplidorID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSuplidores
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
        [Route("[action]/{SuplidorID}/{Empresa}/{Representante}")]
        public async Task<IActionResult> ConsultarSuplidorPorSuplidorIDEmpresaRepresentante([FromRoute]int SuplidorID, string Empresa, string Representante)
        {
            try
            {
                var GetSuplidores = await BuscarSuplidoresPorEmpresaRepresentante(SuplidorID, Empresa, Representante);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSuplidores
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
        public async Task<IActionResult> registrar([FromBody] Suplidore suplidore)
        {
            try
            {


                await _GenericRepository.Add(suplidore);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Suplidor se registro correctamente",
                    data = suplidore
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Suplidor no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Suplidores/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Suplidore suplidore)
        {
            try
            {

                await _GenericRepository.Update(suplidore);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = suplidore

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
        private async Task<List<SuplidoresListView>> SuplidoresListViews()
        {

            var SuplidoresList = new List<SuplidoresListView>();


            SuplidoresList = await _UnitOfWork.context.Suplidores.Select(a => new SuplidoresListView()
            {
                SuplidorID=a.SuplidorID,
                Empresa = a.Empresa,
                Nombre_Suplidor=a.Nombre_Suplidor,
                No_Telefono = a.No_Telefono

            }).ToListAsync();

            return SuplidoresList;

        }

        private async Task<SuplidorById> SuplidoresCodigo(int id)
        {

            var SuplidorList = new SuplidorById();


            SuplidorList = await _UnitOfWork.context.Suplidores
               .Where(a => a.SuplidorID == id)
                .Select(a => new SuplidorById()
                {
                    SuplidorID = a.SuplidorID,
                    Empresa=a.Empresa,
                    Nombre_Suplidor=a.Nombre_Suplidor,
                    No_Telefono=a.No_Telefono,
                    Correo_Electronico=a.Correo_Electronico,
                    Pais=a.Pais,
                    Ciudad=a.Ciudad,
                    Direccion=a.Direccion

                }).FirstOrDefaultAsync();

            return SuplidorList;

        }

        private async Task<List<SuplidoresListView>> BuscarSuplidoresPorEmpresaRepresentante(int SuplidorID,string Empresa, string Representante)
        {
            var SuplidoresList = new List<SuplidoresListView>();

            SuplidoresList = await _UnitOfWork.context.Suplidores
           .Where(a => a.SuplidorID==SuplidorID || a.Empresa == Empresa || a.Nombre_Suplidor == Representante)
           .Select(a => new SuplidoresListView()
           {
               SuplidorID=a.SuplidorID,
               Empresa=a.Empresa,
               Nombre_Suplidor=a.Nombre_Suplidor,
               No_Telefono=a.No_Telefono,
               Correo_Electronico=a.Correo_Electronico,
               Pais=a.Pais,
               Ciudad=a.Ciudad,
               Direccion=a.Direccion
           }).ToListAsync();

            return SuplidoresList;
        }
    }
}