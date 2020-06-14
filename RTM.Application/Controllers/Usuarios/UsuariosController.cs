using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTM.Repository.Interface;
using RTM.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using RTM.Models.DTO;

namespace RTM.Application.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Usuario> _GenericRepository;

        public UsuariosController(IUnitOfWork UnitOfWork, IGenericRepository<Usuario> GenericRepository)
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

                var GetUser = await _UnitOfWork.context.Usuarios.ToListAsync();

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

        // GET: api/Usuarios
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> IniciarSesionApi([FromBody] IniciarSesion iniciarSesion)
        {
            try
            {


                var esValido = await IniciarSesion(iniciarSesion.NombreUsuario, iniciarSesion.contrasena);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = esValido
                }) ;
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

                var GetUser = await _UnitOfWork.context.Usuarios.Where(x => x.UsuarioID == id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> registrar([FromBody] Usuario usuario)
        {
            try
            {


                await _GenericRepository.Add(usuario);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El usuario se registro correctamente",
                    data = usuario
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
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Usuario usuario)
        {
            try
            {

                await _GenericRepository.Update(usuario);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = usuario

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


        //Metodos Funcionalidas Especifica
       
        private async Task<bool> IniciarSesion(string nombreUsuario,string contrasena) 
        {
            bool valor =false;

            var esValida = await _UnitOfWork.context.Usuarios.Where(x => x.NombreDeUsuario == nombreUsuario && x.Contrasena == contrasena).CountAsync();

            //var esValidaLinq = await (from s in _UnitOfWork.context.Usuarios
            //                    where s.NombreDeUsuario == nombreUsuario && s.Contrasena == contrasena           
            //                    select s.NombreDeUsuario).CountAsync();
                               



            if (esValida == 1)
            {
                valor= true;
            }
            else if(esValida == 0)
            {
               valor =false;
            }
            
            return valor;

        
        }
    }
}
