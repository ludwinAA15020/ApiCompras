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
    public class RequisicionController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public RequisicionController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetRequisicion()
        {
            try
            {
                var listRequisicion = await _context.Requisicions.ToListAsync();
                return Ok(listRequisicion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CotizacionController>/5
        [HttpGet("{id}")]

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetRequisicionById(int Id)
        {
            try
            {
                return Ok(await _context.Requisicions.Where(x => x.Idrequisicion == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostRequisicion([FromBody] Requisicion requisicion)
        {
            try
            {
                _context.Add(requisicion);
                await _context.SaveChangesAsync();
                return Ok(requisicion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotizacion(int id, [FromBody] Requisicion requisicion)
        {
            try
            {
                if (id != Convert.ToInt32(requisicion.Idrequisicion))
                {
                    return NotFound();
                }
                _context.Update(requisicion);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La requisicion fue actualizada con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisicion(int id)

        {
            try
            {
                var requisicion = await _context.Requisicions.FindAsync(id);
                if (requisicion == null)
                {
                    return NotFound();
                }
                _context.Requisicions.Remove(requisicion);
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
