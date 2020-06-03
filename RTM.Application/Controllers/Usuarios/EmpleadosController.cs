using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {



        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Empleado> _GenericRepository;

        public EmpleadosController(IUnitOfWork UnitOfWork, IGenericRepository<Empleado> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Usuarios
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetUser = await _UnitOfWork.context.Empleados.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetUser
                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = true,
                    message = "El usuario se registro correctamente",
                    data = ex.Message
                });
            }



        }

        // GET: api/Usuarios/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetUser = await _UnitOfWork.context.Empleados.Where(x => x.EmpleadoID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetUser
                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = true,
                    message = "El usuario se registro correctamente",
                    data = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> register([FromBody] Empleado empleado)
        {
            try
            {
             
              
                await _GenericRepository.Add(empleado);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El usuario se registro correctamente",
                    data = empleado
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = true,
                    message = "El usuario se registro correctamente",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Usuarios/5
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Empleado empleado)
        {
            try
            {

                await _GenericRepository.Update(empleado); 
                 _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = empleado
                    
                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = true,
                    message = "El usuario se registro correctamente",
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
