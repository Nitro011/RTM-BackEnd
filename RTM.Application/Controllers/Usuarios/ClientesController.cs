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
    public class ClientesController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Cliente> _GenericRepository;

        public ClientesController(IUnitOfWork UnitOfWork, IGenericRepository<Cliente> GenericRepository)
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

                var GetUser = await _UnitOfWork.context.Clientes.ToListAsync();

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

                var GetUser = await _UnitOfWork.context.Clientes.Where(x => x.ClienteID == id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> register([FromBody] Cliente cliente)
        {
            try
            {


                await _GenericRepository.Add(cliente);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El usuario se registro correctamente",
                    data = cliente
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
        public async Task<IActionResult> modificar([FromBody] Cliente cliente)
        {
            try
            {

                await _GenericRepository.Update( cliente);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = cliente

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
