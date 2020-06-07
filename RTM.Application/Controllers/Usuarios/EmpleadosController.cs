using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO;
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
        public async Task<IActionResult> register([FromBody] UsuariosEmpleadosDTO usuario)
        {
            try
            {


                var empleado = new Empleado()
                {
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Sexo = usuario.Sexo,
                    Cedula = usuario.Cedula,
                    Fecha_Nacimiento = usuario.Fecha_Nacimiento,
                    Edad = usuario.Edad,
                    Direccion = usuario.Direccion,
                    Telefono = usuario.Telefono

                };

                await _UnitOfWork.context.Empleados.AddAsync(empleado);
                _UnitOfWork.Commit();


                var user = new Usuario()
                {

                    UserName = usuario.UserName,
                    LockoutEnabled = true,
                    Email = usuario.Email,
                    RolID = usuario.RolID,
                    EmpleadoID = empleado.EmpleadoID

                };

                var pass = Encriptar(usuario.PasswordHash);
                user.PasswordHash = pass;
                await _UnitOfWork.context.Usuarios.AddAsync(user);
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

        private string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}
