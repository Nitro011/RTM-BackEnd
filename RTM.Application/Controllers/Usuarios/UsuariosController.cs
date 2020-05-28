using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Persistence;
using RTM.Repository.Interface;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> login([FromBody] Usuario usuario)
        {
            try
            {
             var isValid = await loguear(usuario);


                return Ok(new Request()
                {
                    status = true,
                    message = "El usuario se registro correctamente",
                    data = isValid
                }); ;
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
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                var pass = Encriptar(usuario.PasswordHash);
                usuario.PasswordHash = pass;
                usuario.LockoutEnabled = true;
                await _GenericRepository.Add(usuario);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El usuario se logueo correctamente",
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        private async Task<bool> loguear(Usuario usuario) 
        {

            var pass = Encriptar(usuario.PasswordHash);

          var isOne = await _UnitOfWork.context.Usuarios.Where(x => x.UserName == usuario.UserName && x.PasswordHash == pass && x.LockoutEnabled == true).CountAsync();


            if (isOne == 1)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        /// Encripta una cadena
        private  string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        private  string DesEncriptar( string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }


    }
}
