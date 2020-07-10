using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers.DimensionesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IGenericRepository<Size> _GenericRepository;

        public SizeController(IUnitOfWork UnitOfWork, IGenericRepository<Size> GenericRepository)
        {
            this._UnitOfWork = UnitOfWork;
            this._GenericRepository = GenericRepository;
        }


        // GET: api/Dimensiones
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> lista()
        {
            try
            {

                var GetSizes = await _UnitOfWork.context.Sizes.ToListAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSizes 
                });
            }
            catch (Exception ex)
            {
                return Ok(new Request()
                {
                    status = true,
                    message = "Ocurrio un error inesperado!!",
                    data = ex.Message
                });
            }



        }

        // GET: api/Size/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> listaPorId(int id)
        {
            try
            {

                var GetSizes = await _UnitOfWork.context.Sizes.Where(x => x.SizeID == id).FirstOrDefaultAsync();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = GetSizes
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
        public async Task<IActionResult> registrar([FromBody] Size size)
        {
            try
            {


                await _GenericRepository.Add(size);
                _UnitOfWork.Commit();


                return Ok(new Request()
                {
                    status = true,
                    message = "El Size se registro correctamente",
                    data = size
                });
            }
            catch (Exception ex)
            {

                return Ok(new Request()
                {
                    status = false,
                    message = "El Size no se registro correctamente!!",
                    data = ex.Message
                });
            }


        }

        // PUT: api/Colores/5
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> modificar([FromBody] Size size)
        {
            try
            {

                await _GenericRepository.Update(size);
                _UnitOfWork.Commit();

                return Ok(new Request()
                {
                    status = true,
                    message = "Esta accion se ejecuto correctamente",
                    data = size

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
    }
}