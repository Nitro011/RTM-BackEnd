using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.DTO.AnchosSize;
using RTM.Models.TableDB;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.AnchosSizesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnchosSizeController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<AnchosSizes> _GenericRepository;

        public AnchosSizeController(IUnitOfWork UnitOfWork, IGenericRepository<AnchosSizes> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/AnchosSizes
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetAnchosSizes = await _UnitOfWork.context.AnchosSizes.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetAnchosSizes
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

        // GET: api/AnchosSizes/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetAnchosSizes = await _UnitOfWork.context.AnchosSizes.Where(x => x.AnchoSizeID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetAnchosSizes
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
        [Route("[action]/{AnchosSizes}")]
        public async Task<IActionResult> ConsultarAnchosSizesPorAnchoSizes([FromRoute]string AnchosSizes)
        {
            try
            {
                var GetAnchosSizes = await BuscarAnchosSizesPorAnchoSizes(AnchosSizes);

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetAnchosSizes
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
        public async Task<IActionResult> registrar([FromBody] AnchosSizes anchosSizes)
        {
            try
            {


                await _GenericRepository.Add(anchosSizes);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Ancho del Sizes se registro correctamente",
                    data = anchosSizes
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Ancho del Sizes no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Colores/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] AnchosSizes anchosSizes)
        {
            try
            {

                await _GenericRepository.Update(anchosSizes);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = anchosSizes

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

        private async Task<List<AnchosSizesListView>> BuscarAnchosSizesPorAnchoSizes(string AnchosSizes)
        {
            var AnchosSizesList = new List<AnchosSizesListView>();

            AnchosSizesList = await _UnitOfWork.context.AnchosSizes
           .Where(a => a.AnchoSize==AnchosSizes)
           .Select(a => new AnchosSizesListView()
           {
               AnchoSizeID=a.AnchoSizeID,
               AnchoSize=a.AnchoSize

           }).ToListAsync();

            return AnchosSizesList;
        }
    }
}