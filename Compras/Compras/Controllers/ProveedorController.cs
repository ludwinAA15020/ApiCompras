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
    public class ProveedorController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public ProveedorController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetProveedor()
        {
            try
            {
                var listProveedor = await _context.Proveedors.ToListAsync();
                return Ok(listProveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public string getproducto(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GetProveedorById(int Id)
        {
            try
            {
                return Ok(await _context.Proveedors.Where(x => x.Idproveedores == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostProveedor([FromBody] Proveedor proveedor)
        {
            try
            {
                _context.Add(proveedor);
                await _context.SaveChangesAsync();
                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, [FromBody] Proveedor proveedor)
        {
            try
            {
                if (id != Convert.ToInt32(proveedor.Idproveedores))
                {
                    return NotFound();
                }
                _context.Update(proveedor);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El Proveedor fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)

        {
            try
            {
                var proveedor = await _context.Proveedors.FindAsync(id);
                if (proveedor == null)
                {
                    return NotFound();
                }
                _context.Proveedors.Remove(proveedor);
                await _context.SaveChangesAsync();
                return Ok(new { message = "proveedor eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
