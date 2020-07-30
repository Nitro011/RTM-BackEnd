using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.Roles;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.RolesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Role> _GenericRepository;

        public RoleController(IUnitOfWork UnitOfWork, IGenericRepository<Role> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Roles
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetRoles = await _UnitOfWork.context.Roles.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetRoles
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

        // GET: api/Roles/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetRoles = await _UnitOfWork.context.Roles.Where(x => x.RolID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetRoles
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

        //Get: api/Roles/TipoUsuario:
        [HttpGet]
        [Route("[action]/{TipoUsuario}")]
        public async Task<IActionResult> BuscarRolesPorTipoUsuario([FromRoute]string TipoUsuario)
        {
            try
            {
                var GetRoles = await BuscarRolPorTipoUsuario(TipoUsuario);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetRoles
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
        public async Task<IActionResult> registrar([FromBody] Role role)
        {
            try
            {


                await _GenericRepository.Add(role);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Rol se registro correctamente",
                    data = role
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Rol no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Roles/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Role role)
        {
            try
            {

                await _GenericRepository.Update(role);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = role

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
        private async Task<List<RolesByTipoUsuario>> BuscarRolPorTipoUsuario(string TipoUsuario)
        {
            var RolesList = new List<RolesByTipoUsuario>();

            RolesList = await _UnitOfWork.context.Roles
                .Where(a => a.Tipo_Usuario==TipoUsuario)
                .Select(a => new RolesByTipoUsuario()
                {
                    RolID = a.RolID,
                    Tipo_Usuario = a.Tipo_Usuario,

                }).ToListAsync();

            return RolesList;
        }
    }
}