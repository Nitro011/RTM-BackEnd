using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.EmpleadosController
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


            // GET: api/Empleados
            [HttpGet]
            [Route("[action]")]
            public async Task<IActionResult> lista()
            {
                try
                {

                    var GetEmpleado = await _UnitOfWork.context.Empleados.ToListAsync();

                    return Ok(new Request()
                    {
                        status = true,
                        message = "Esta accion se ejecuto correctamente",
                        data = GetEmpleado
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

            // GET: api/Empleados/5
            [HttpGet]
            [Route("[action]/{id}")]
            public async Task<IActionResult> listaPorId(int id)
            {
                try
                {

                    var GetEmpleados = await _UnitOfWork.context.Empleados.Where(x => x.EmpleadoID == id).FirstOrDefaultAsync();

                    return Ok(new Request()
                    {
                        status = true,
                        message = "Esta accion se ejecuto correctamente",
                        data = GetEmpleados
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
            public async Task<IActionResult> registrar([FromBody] Empleado empleado)
            {
                try
                {


                    await _GenericRepository.Add(empleado);
                    _UnitOfWork.Commit();


                    return Ok(new Request()
                    {
                        status = true,
                        message = "El empleado se registro correctamente",
                        data = empleado
                    });
                }
                catch (Exception ex)
                {

                    return Ok(new Request()
                    {
                        status = false,
                        message = "El empleado no se registro correctamente!!",
                        data = ex.Message
                    });
                }


            }

            // PUT: api/Usuarios/5
            [HttpPost]
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
                        status = false,
                        message = "Ocurrio un error inesperado!!",
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
