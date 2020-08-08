﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTM.Models;
using RTM.Models.DTO.Estilos;
using RTM.Models.TableDB;
using RTM.Repository.Interface;
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace RTM.Application.Controllers.EstiloController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstilosNuevosController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Estilos> _GenericRepository;

        public EstilosNuevosController(IUnitOfWork UnitOfWork, IGenericRepository<Estilos> GenericRepository)
        {
            this._GenericRepository = GenericRepository;
            this._UnitOfWork = UnitOfWork;
        }



        // GET: api/<EstilosNuevosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EstilosNuevosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EstilosNuevosController>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> registrar([FromBody] Estilos estilos)
        {
            try
            {


                await _GenericRepository.Add(estilos);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "La Marca se registro correctamente"

                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "La Marca no se registro correctamente!!",
                    data = ex.Message
                });
            }

        }

        // GET: api/Empleados
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EstilosList()
        {
            try
            {

                var GetEstilos = await EstilosListViews();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetEstilos
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
        [Route("[action]/{EstiloNo}")]
        public async Task<IActionResult> ConsultarEstilosPorEstiloNo([FromRoute]int EstiloNo)
        {
            try
            {
                var GetEstilos = await BuscarEstilosPorEstiloNo(EstiloNo);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetEstilos
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

        // PUT api/<EstilosNuevosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstilosNuevosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //Funciones:
        private async Task<List<EstilosListView>> EstilosListViews()
        {

            var EstilosList = new List<EstilosListView>();


            EstilosList = await _UnitOfWork.context.Estilos.Select(a => new EstilosListView()
            {
                EstiloID = a.EstiloID,
                Estilo_No = a.Estilo_No,
                Marcas = _UnitOfWork.context.Estilos.Include(x=>x.Marcas).Where(x => x.MarcaID==a.MarcaID).Select(a => a.Marcas.Marca1).FirstOrDefault(),
                Modelos= _UnitOfWork.context.Estilos_Modelos.Include(x=>x.Estilos).ThenInclude(x=>x.Modelos).Where(x=>x.EstiloID==a.EstiloID).Select(a=>a.Modelo.Modelo1).FirstOrDefault(),
                TiposEstilos= _UnitOfWork.context.Estilos_TiposEstilos.Include(x => x.Estilos).ThenInclude(x=>x.TiposEstilos).Where(x => x.EstiloID == a.EstiloID).Select(a => a.Tipo_Calzados.Tipo_Calzado).FirstOrDefault(),
                Categorias= _UnitOfWork.context.Estilos_CategoriasEstilos.Include(x => x.Estilos).ThenInclude(x=>x.CategoriasEstilos).Where(x => x.EstiloID == a.EstiloID).Select(a => a.CategoriasEstilos.CategoriaEstilo).FirstOrDefault(),
                Materiales= _UnitOfWork.context.Estilos_MateriasPrimas.Include(x => x.Estilos).ThenInclude(x=>x.Materias).Where(x => x.EstiloID==a.EstiloID).Select(a => a.Materias_Primas.Nombre_Materia_Prima).FirstOrDefault(),
                PesosEstilos=_UnitOfWork.context.Estilos_PesosEstilos.Include(x=>x.Estilos).ThenInclude(x=>x.PesosEstilos).Where(x=>x.EstiloID==a.EstiloID).Select(a=>a.PesosEstilos.PesoEstilo).FirstOrDefault(),
                Last=a.Last,
                UnidadesMedidas= _UnitOfWork.context.Estilos.Include(x=>x.UnidadesMedidasEstilos).Where(x=>x.UnidadMedidaEstiloID==a.UnidadMedidaEstiloID).Select(a=>a.UnidadesMedidasEstilos.UnidadMedidaEstilo).FirstOrDefault(),
                Colores= _UnitOfWork.context.Estilos_Colores.Include(x => x.Estilos).ThenInclude(x => x.Colores).Where(x => x.EstiloID == a.EstiloID).Select(a => a.Colore.Color).FirstOrDefault(),
                Division= _UnitOfWork.context.Estilos.Include(x => x.Divisiones).Where(x => x.DivisionID==a.DivisionID).Select(a=>a.Divisiones.Division).FirstOrDefault(),
                Descripcion=a.Descripcion,
                Comentarios=a.Comentarios,
                CostoSTD=a.CostoSTD,
                Ganancia=a.Ganancia,
                FechaCreacion=a.FechaCreacion,
                PattenNo=a.PattenNo,
                Estados= _UnitOfWork.context.Estilos.Include(x => x.Estado).Where(x => x.EstadoID == a.EstadoID).Select(a => a.Estado.Estado1).FirstOrDefault()

            }).ToListAsync();

            return EstilosList;

        }

        private async Task<List<EstilosListView>> BuscarEstilosPorEstiloNo(int EstiloNo)
        {
            var EstilosList = new List<EstilosListView>();

                 EstilosList = await _UnitOfWork.context.Estilos
                .Where(a => a.Estilo_No==EstiloNo)
                .Select(a => new EstilosListView()
                {
                    EstiloID = a.EstiloID,
                    Estilo_No = a.Estilo_No,
                    Marcas = _UnitOfWork.context.Estilos.Include(x => x.Marcas).Where(x => x.MarcaID == a.MarcaID).Select(a => a.Marcas.Marca1).FirstOrDefault(),
                    Modelos = _UnitOfWork.context.Estilos_Modelos.Include(x => x.Estilos).ThenInclude(x => x.Modelos).Where(x => x.EstiloID == a.EstiloID).Select(a => a.Modelo.Modelo1).FirstOrDefault(),
                    TiposEstilos = _UnitOfWork.context.Estilos_TiposEstilos.Include(x => x.Estilos).ThenInclude(x => x.TiposEstilos).Where(x => x.EstiloID == a.EstiloID).Select(a => a.Tipo_Calzados.Tipo_Calzado).FirstOrDefault(),
                    Categorias = _UnitOfWork.context.Estilos_CategoriasEstilos.Include(x => x.Estilos).ThenInclude(x => x.CategoriasEstilos).Where(x => x.EstiloID == a.EstiloID).Select(a => a.CategoriasEstilos.CategoriaEstilo).FirstOrDefault(),
                    Materiales = _UnitOfWork.context.Estilos_MateriasPrimas.Include(x => x.Estilos).ThenInclude(x => x.Materias).Where(x => x.EstiloID == a.EstiloID).Select(a => a.Materias_Primas.Nombre_Materia_Prima).FirstOrDefault(),
                    PesosEstilos = _UnitOfWork.context.Estilos_PesosEstilos.Include(x => x.Estilos).ThenInclude(x => x.PesosEstilos).Where(x => x.EstiloID == a.EstiloID).Select(a => a.PesosEstilos.PesoEstilo).FirstOrDefault(),
                    Last = a.Last,
                    UnidadesMedidas = _UnitOfWork.context.Estilos.Include(x => x.UnidadesMedidasEstilos).Where(x => x.UnidadMedidaEstiloID == a.UnidadMedidaEstiloID).Select(a => a.UnidadesMedidasEstilos.UnidadMedidaEstilo).FirstOrDefault(),
                    Colores = _UnitOfWork.context.Estilos_Colores.Include(x => x.Estilos).ThenInclude(x => x.Colores).Where(x => x.EstiloID == a.EstiloID).Select(a => a.Colore.Color).FirstOrDefault(),
                    Division = _UnitOfWork.context.Estilos.Include(x => x.Divisiones).Where(x => x.DivisionID == a.DivisionID).Select(a => a.Divisiones.Division).FirstOrDefault(),
                    Descripcion = a.Descripcion,
                    Comentarios = a.Comentarios,
                    CostoSTD = a.CostoSTD,
                    Ganancia = a.Ganancia,
                    FechaCreacion = a.FechaCreacion,
                    PattenNo = a.PattenNo,
                    Estados = _UnitOfWork.context.Estilos.Include(x => x.Estado).Where(x => x.EstadoID == a.EstadoID).Select(a => a.Estado.Estado1).FirstOrDefault()

                }).ToListAsync();

            return EstilosList;
        }
    }
}
