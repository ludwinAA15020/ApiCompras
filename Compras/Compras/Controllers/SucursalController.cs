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
    public class SucursalController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public SucursalController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetSucursal()
        {
            try
            {
                var listSucursal = await _context.Sucursals.ToListAsync();
                return Ok(listSucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CotizacionController>/5

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetSucursalById(int Id)
        {
            try
            {
                return Ok(await _context.Sucursals.Where(x => x.Idsucursal == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostSucursal([FromBody] Sucursal sucursal)
        {
            try
            {
                _context.Add(sucursal);
                await _context.SaveChangesAsync();
                return Ok(sucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursal(int id, [FromBody] Sucursal sucursal)
        {
            try
            {
                if (id != Convert.ToInt32(sucursal.Idsucursal))
                {
                    return NotFound();
                }
                _context.Update(sucursal);
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
                var sucursal = await _context.Sucursals.FindAsync(id);
                if (sucursal == null)
                {
                    return NotFound();
                }
                _context.Sucursals.Remove(sucursal);
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
