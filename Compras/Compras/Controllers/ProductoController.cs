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
    public class ProductoController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public ProductoController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetProducto()
        {
            try
            {
                var listProductos = await _context.Productos.ToListAsync();
                return Ok(listProductos);
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
        public async Task<IActionResult> GetProductoById(int Id)
        {
            try
            {
                return Ok(await _context.Productos.Where(x => x.Idproducto == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostProducto([FromBody] Producto producto)
        {
            try
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, [FromBody] Producto producto)
        {
            try
            {
                if (id != Convert.ToInt32(producto.Idproducto))
                {
                    return NotFound();
                }
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El Producto fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)

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
                return Ok(new { message = "producto eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
