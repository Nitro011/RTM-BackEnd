using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.Modelos;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.ModelosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Modelo> _GenericRepository;

        public ModelosController(IUnitOfWork UnitOfWork, IGenericRepository<Modelo> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Modelos
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetModelos = await _UnitOfWork.context.Modelos.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetModelos
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

        // GET: api/Modelos/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetModelos = await _UnitOfWork.context.Modelos.Where(x => x.ModeloID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetModelos
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
        [Route("[action]/{Modelos}")]
        public async Task<IActionResult> ConsultarModelosPorModelos([FromRoute]string Modelos)
        {
            try
            {
                var GetModelos = await BuscarModelosPorModelos(Modelos);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetModelos
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
        public async Task<IActionResult> registrar([FromBody] Modelo modelo)
        {
            try
            {


                await _GenericRepository.Add(modelo);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Modelo se registro correctamente",
                    data = modelo
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Modelo no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Modelos/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Modelo modelo)
        {
            try
            {

                await _GenericRepository.Update(modelo);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = modelo

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
        private async Task<List<ModelosListView>> BuscarModelosPorModelos(string Modelo)
        {
            var ModelosList = new List<ModelosListView>();

                ModelosList = await _UnitOfWork.context.Modelos
                .Where(a => a.Modelo1==Modelo)
                .Select(a => new ModelosListView()
                {
                   ModeloID=a.ModeloID,
                   Modelo1=a.Modelo1,

                }).ToListAsync();

            return ModelosList;
        }
    }
}