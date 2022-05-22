using Compras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Compras.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenciasController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public ReferenciasController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetReferencia()
        {
            try
            {
                var listCotizacion = await _context.Referencia.ToListAsync();
                return Ok(listCotizacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CotizacionController>/5

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetReferenciById(int Id)
        {
            try
            {
                return Ok(await _context.Referencia.Where(x => x.Idreferencia == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostReferencia([FromBody] Referencium referencia)
        {
            try
            {
                _context.Add(referencia);
                await _context.SaveChangesAsync();
                return Ok(referencia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotizacion(int id, [FromBody] Referencium referencia)
        {
            try
            {
                if (id != Convert.ToInt32(referencia.Idreferencia))
                {
                    return NotFound();
                }
                _context.Update(referencia);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La referencia fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferencia(int id)

        {
            try
            {
                var referencia = await _context.Referencia.FindAsync(id);
                if (referencia == null)
                {
                    return NotFound();
                }
                _context.Referencia.Remove(referencia);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La cotizacion eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
