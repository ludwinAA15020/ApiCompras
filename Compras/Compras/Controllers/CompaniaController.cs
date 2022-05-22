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
    public class CompaniaController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public CompaniaController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetCompania()
        {
            try
            {
                var listCompania = await _context.Compania.ToListAsync();
                return Ok(listCompania);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CotizacionController>/5
        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GetCompaniaById(int Id)
        {
            try
            {
                return Ok(await _context.Compania.Where(x => x.Idcompania == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostCompania([FromBody] Companium compania)
        {
            try
            {
                _context.Add(compania);
                await _context.SaveChangesAsync();
                return Ok(compania);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompania(int id, [FromBody] Companium compania)
        {
            try
            {
                if (id != Convert.ToInt32(compania.Idcompania))
                {
                    return NotFound();
                }
                _context.Update(compania);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La Compania fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        


        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompania(int id)

        {
            try
            {
                var compania = await _context.Compania.FindAsync(id);
                if (compania == null)
                {
                    return NotFound();
                }
                _context.Compania.Remove(compania);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La Compania eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
