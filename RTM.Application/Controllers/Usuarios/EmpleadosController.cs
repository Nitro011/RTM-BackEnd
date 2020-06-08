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

                var GetUser = await EmpleadosListViews();

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

                var GetUser = await UsuarioEmpleado(id);

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
        public async Task<IActionResult> modificar([FromBody] UsuariosEmpleadosDTO usuarios)
        {
            try
            {
                var pass = Encriptar(usuarios.PasswordHash);

                usuarios.PasswordHash = pass;
                await modificarEmpleado(usuarios);

                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente"
                    

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

        //Funciones
        private async Task<List<EmpleadosListView>> EmpleadosListViews()
        {
            return await _UnitOfWork.context.Usuarios
                .Include(x => x.Empleado)
                .Include(x => x.Role)
                .Where(x=>x.UsuarioID != 1)
                .Select(x => new EmpleadosListView()
                {

                    Id = (x.Empleado != null) ? x.Empleado.EmpleadoID : 0,
                    NombreCompleto = (x.Empleado != null) ? $"Nombre: {x.Empleado.Nombres } {x.Empleado.Apellidos}" : "",
                    Puesto = (x.Role != null) ? $"Cargo ocupado: {x.Role.Tipo_Usuario}" : ""

                }).ToListAsync();

        }

        private async Task modificarEmpleado(UsuariosEmpleadosDTO usuarioEmpleado)
        {
            var empleado = await _UnitOfWork.context.Empleados.Where(x => x.EmpleadoID == usuarioEmpleado.EmpleadoId).FirstOrDefaultAsync();
            var usuario = await _UnitOfWork.context.Usuarios.Where(x => x.EmpleadoID == usuarioEmpleado.EmpleadoId).FirstOrDefaultAsync();

            usuario.EmpleadoID = usuarioEmpleado.EmpleadoId;
            usuario.RolID = usuarioEmpleado.RolID;
            usuario.LockoutEnabled = usuarioEmpleado.LockoutEnabled;
            usuario.PasswordHash = usuarioEmpleado.PasswordHash;
            usuario.UserName = usuarioEmpleado.UserName;
            usuario.Email = usuarioEmpleado.Email;
            empleado.Nombres = usuarioEmpleado.Nombres;
            empleado.Apellidos = usuarioEmpleado.Apellidos;
            empleado.Sexo = usuarioEmpleado.Sexo;
            empleado.Cedula = usuarioEmpleado.Cedula;
            empleado.Fecha_Nacimiento = usuarioEmpleado.Fecha_Nacimiento;
            empleado.Edad = usuarioEmpleado.Edad;
            empleado.Direccion = usuarioEmpleado.Direccion;
            empleado.Telefono = usuarioEmpleado.Telefono;

            _UnitOfWork.context.Entry(empleado).State = EntityState.Modified;
            _UnitOfWork.context.Entry(usuario).State = EntityState.Modified;

            await Task.CompletedTask;
        }

        private async Task<UsuarioById> UsuarioEmpleado(int id)
        {
            return await _UnitOfWork.context.Usuarios
                   .Include(x => x.Empleado)
                   .Include(x => x.Role)
                   .Where(x => x.EmpleadoID == id && x.LockoutEnabled == true)
                   .Select(x => new UsuarioById()
                   {
                       IdEmpleado = (x.Empleado != null) ? x.Empleado.EmpleadoID : 0,
                       Nombre = (x.Empleado != null) ? $"{x.Empleado.Nombres} {x.Empleado.Apellidos}" : "",
                       sexo = (x.Empleado != null) ? (bool)x.Empleado.Sexo : true,
                       cedula = (x.Empleado != null) ? x.Empleado.Cedula : "",
                       fecha_nacimiento = (x.Empleado != null) ? x.Empleado.Fecha_Nacimiento : DateTime.MinValue,
                       edad = (x.Empleado != null) ? (int)x.Empleado.Edad : 0,
                       direccion = (x.Empleado != null) ? x.Empleado.Direccion : "",
                       telefono = (x.Empleado != null) ? x.Empleado.Telefono : "",
                       puesto = (x.Role != null) ? x.Role.Tipo_Usuario : ""


                   }).FirstOrDefaultAsync();


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
