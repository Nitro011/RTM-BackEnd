using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.EstadosUsuariosAlmacen
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosUsuariosAlmacenController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Estados_Usuarios_Almacen> _GenericRepository;

        public EstadosUsuariosAlmacenController(IUnitOfWork UnitOfWork, IGenericRepository<Estados_Usuarios_Almacen> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Estados_Usuarios_Almacen
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetEstadosUsuariosAlmacen = await _UnitOfWork.context.Estados_Usuarios_Almacen.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetEstadosUsuariosAlmacen
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

        // GET: api/Estados_Usuarios_Almacen/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetEstadosUsuariosAlmacen = await _UnitOfWork.context.Estados_Usuarios_Almacen.Where(x => x.Estado_Usuario_AlmacenID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetEstadosUsuariosAlmacen
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
        public async Task<IActionResult> registrar([FromBody] Estados_Usuarios_Almacen estados_Usuarios_Almacen)
        {
            try
            {


                await _GenericRepository.Add(estados_Usuarios_Almacen);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Estado_Usuario_Almacen se registro correctamente",
                    data = estados_Usuarios_Almacen
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Estado_Usuario_Almacen no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Estados_Usuarios_Almacen/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Estados_Usuarios_Almacen estados_Usuarios_Almacen)
        {
            try
            {

                await _GenericRepository.Update(estados_Usuarios_Almacen);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = estados_Usuarios_Almacen

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