using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO;
using RTM.Models.DTO.Empleados;
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

        // GET: api/Empleados
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> EmpleadoPorCodigo([FromRoute]int id)
        {
            try
            {

                var GetEmpleado = await EmpleadosCodigo(id);

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

        //Get: api/Empleados:
        //Api para buscar empleado por su cedula:
        //Buscar empleado por su cedula:
        [HttpGet]
        [Route("[action]/{cedula}")]
        public async Task<IActionResult> EmpleadoPorCedula([FromRoute]string cedula)
        {
            try
            {

                var GetEmpleado = await EmpleadoCedula(cedula);

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

        [HttpGet]
        [Route("[action]/{Nombres}/{Apellidos}/{Cedula}/{CodigoEmpleado}")]
        public async Task<IActionResult> EmpleadoPorNombresApellidosCedulaCodigoEmpleado([FromRoute]string Nombres, string Apellidos, string Cedula, string CodigoEmpleado)
        {
            try
            {
                var GetEmpleado = await EmpleadoPorNombres_Apellidos_Cedula_CodigoEmpleado(Nombres, Apellidos, Cedula, CodigoEmpleado);

                return Ok(new Request()
                {
                    status=true,
                    message="Esta accion se ejecuto correctamente",
                    data=GetEmpleado
                });
            }
            catch(Exception ex)
            {
                return Ok(new Request()
                {
                    status = false,
                    message = "Ocurrio un error inesperado!!",
                    data = ex.Message
                });
            }
        }

        // GET: api/Empleados
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EmpleadosList()
        {
            try
            {

                var GetEmpleado = await EmpleadosListViews();

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



        //Funciones
        private async Task<List<EmpleadosListView>> EmpleadosListViews()
        {

            var EmpleadoList = new List<EmpleadosListView>();


            EmpleadoList = await _UnitOfWork.context.Empleados.Select(a => new EmpleadosListView()
            {
                Id = a.EmpleadoID,
                NombreCompleto = $"{a.Nombres} {a.Apellidos}",
                Puesto = _UnitOfWork.context.Empleados.Include(x => x.AreaProduccion).Where(x => x.EmpleadoID == a.EmpleadoID).Select(a => a.AreaProduccion.NombreAreaProduccion).FirstOrDefault(),
                Posicion = _UnitOfWork.context.Empleados.Include(x => x.Role).Where(x => x.EmpleadoID == a.EmpleadoID).Select(a => a.Role.Tipo_Usuario).FirstOrDefault(),
                FechaIngreso = a.FechaIngreso.ToString()

            }).ToListAsync();

            return EmpleadoList;

        }

        private async Task<UsuarioById> EmpleadosCodigo(int id)
        {

            var EmpleadoList = new UsuarioById();


            EmpleadoList = await _UnitOfWork.context.Empleados
               .Where(a => a.EmpleadoID == id)
                .Select(a => new UsuarioById()
                {
                    EmpleadoID = a.EmpleadoID,
                    NombresApellidos = $"{a.Nombres} {a.Apellidos}",
                    Sexo = (a.Sexo == true) ? "Masculino" : "Femenino",
                    Cedula = a.Cedula,
                    Fecha_Nacimiento = a.Fecha_Nacimiento,
                    Edad = a.Edad,
                    Direccion = a.Direccion,
                    Telefono = a.Telefono,
                    Puesto = _UnitOfWork.context.Usuarios.Include(x => x.AreaProduccion).Where(x => x.EmpleadoID == a.EmpleadoID).Select(a => a.AreaProduccion.NombreAreaProduccion).FirstOrDefault(),
                    Rol = _UnitOfWork.context.Usuarios.Include(x => x.Role).Where(x => x.EmpleadoID == a.EmpleadoID).Select(a => a.Role.Tipo_Usuario).FirstOrDefault(),
                    NombreUsuario = _UnitOfWork.context.Usuarios.Where(x => x.EmpleadoID == a.EmpleadoID).Select(a => a.NombreDeUsuario).FirstOrDefault()

                }).FirstOrDefaultAsync();

            return EmpleadoList;

        }

        private async Task<EmpleadoByCedula> EmpleadoCedula(string Cedula)
        {

            var EmpleadoList = new EmpleadoByCedula();


            EmpleadoList = await _UnitOfWork.context.Empleados
               .Where(a => a.Cedula == Cedula)
                .Select(a => new EmpleadoByCedula()
                {
                    EmpleadoID = a.EmpleadoID,
                    cedula = a.Cedula,
                    nombreCompleto = $"{a.Nombres} {a.Apellidos}",

                }).FirstOrDefaultAsync();

            return EmpleadoList;
        }

        private async Task<List<EmpleadoByNombreCompleto_Cedula_CodigoEmpleado>> EmpleadoPorNombres_Apellidos_Cedula_CodigoEmpleado(string Nombres, string Apellidos, string Cedula, string CodigoEmpleado)
        {
            var EmpleadoList = new List<EmpleadoByNombreCompleto_Cedula_CodigoEmpleado>();

            EmpleadoList = await _UnitOfWork.context.Empleados
                .Where(a => a.Nombres == Nombres || a.Apellidos == Apellidos || a.Cedula == Cedula || a.CodigoEmpleado == CodigoEmpleado || a.Nombres == Nombres && a.Apellidos == Apellidos)
                .Select(a => new EmpleadoByNombreCompleto_Cedula_CodigoEmpleado()
                {
                    Id = a.EmpleadoID,
                    RolID=a.RolID,
                    AreaProduccionID=a.AreaProduccionID,
                    CodigoEmpleado = a.CodigoEmpleado,
                    Nombres=a.Nombres,
                    Apellidos=a.Apellidos,
                    nombreCompleto = $"{a.Nombres} {a.Apellidos}",
                    Sexo=a.Sexo,
                    Cedula=a.Cedula,
                    Fecha_Nacimiento=a.Fecha_Nacimiento,
                    Edad=a.Edad,
                    Direccion=a.Direccion,
                    Telefono=a.Telefono,
                    FechaIngreso=a.FechaIngreso,
                    Posicion = _UnitOfWork.context.Empleados.Include(x => x.Role).Where(x => x.EmpleadoID == a.EmpleadoID).Select(a => a.Role.Tipo_Usuario).FirstOrDefault(),
                    Puesto = _UnitOfWork.context.Empleados.Include(x => x.AreaProduccion).Where(x => x.EmpleadoID == a.EmpleadoID).Select(a => a.AreaProduccion.NombreAreaProduccion).FirstOrDefault(),

                }).ToListAsync();

            return EmpleadoList;
        }


    }
}
