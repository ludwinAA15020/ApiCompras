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
    public class CotizacionController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public CotizacionController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetCotizacion()
        {
            try
            {
                var listCotizacion = await _context.Cotizacions.ToListAsync();
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

        public async Task<IActionResult> GetCotizacionById(int Id)
        {
            try
            {
                return Ok(await _context.Cotizacions.Where(x => x.Idcotizacion == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostCotizacion([FromBody] Cotizacion cotizacion)
        {
            try
            {
                _context.Add(cotizacion);
                await _context.SaveChangesAsync();
                return Ok(cotizacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotizacion(int id, [FromBody] Cotizacion cotizacion)
        {
            try
            {
                if (id != Convert.ToInt32(cotizacion.Idcotizacion))
                {
                    return NotFound();
                }
                _context.Update(cotizacion);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La cotizacion fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCotizacion(int id)

        {
            try
            {
                var producto = await _context.Productos.FindAsync(id);
                if (producto == null)
                {
                    return NotFound();
                }
                _context.Productos.Remove(producto);
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
