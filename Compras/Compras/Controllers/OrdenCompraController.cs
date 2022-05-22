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
    public class OrdenCompraController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public OrdenCompraController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetOrdenCompra()
        {
            try
            {
                var lisOrdenCompra = await _context.Ordencompras.ToListAsync();
                return Ok(lisOrdenCompra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CotizacionController>/5
        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GetOrdenCompraById(int Id)
        {
            try
            {
                return Ok(await _context.Ordencompras.Where(x => x.Idordencompra == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostOrdenCompra([FromBody] Ordencompra ordenCompras)
        {
            try
            {
                _context.Add(ordenCompras);
                await _context.SaveChangesAsync();
                return Ok(ordenCompras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenCompra(int id, [FromBody] Ordencompra ordenCompra)
        {
            try
            {
                if (id != Convert.ToInt32(ordenCompra.Idordencompra))
                {
                    return NotFound();
                }
                _context.Update(ordenCompra);
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
        public async Task<IActionResult> DeleteOrdenCompra(int id)

        {
            try
            {
                var ordenCompras = await _context.Ordencompras.FindAsync(id);
                if (ordenCompras == null)
                {
                    return NotFound();
                }
                _context.Ordencompras.Remove(ordenCompras);
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
