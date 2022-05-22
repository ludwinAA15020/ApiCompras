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
    public class MetodeoPagoController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public MetodeoPagoController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetMetodo()
        {
            try
            {
                var listPago = await _context.Metodopagos.ToListAsync();
                return Ok(listPago);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CotizacionController>/5
        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GetMetodoById(int Id)
        {
            try
            {
                return Ok(await _context.Metodopagos.Where(x => x.Idmetodopago == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostMetodo([FromBody] Metodopago metodo)
        {
            try
            {
                _context.Add(metodo);
                await _context.SaveChangesAsync();
                return Ok(metodo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodo(int id, [FromBody] Metodopago metodo)
        {
            try
            {
                if (id != Convert.ToInt32(metodo.Idmetodopago))
                {
                    return NotFound();
                }
                _context.Update(metodo);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La metodo fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodo(int id)

        {
            try
            {
                var metodo = await _context.Metodopagos.FindAsync(id);
                if (metodo == null)
                {
                    return NotFound();
                }
                _context.Metodopagos.Remove(metodo);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La Metodo eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
