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
    public class PerfilController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public PerfilController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetPerfil()
        {
            try
            {
                var listPerfil = await _context.Perfils.ToListAsync();
                return Ok(listPerfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CotizacionController>/5
        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GetPerfilById(int Id)
        {
            try
            {
                return Ok(await _context.Perfils.Where(x => x.Idperfil == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Postperfil([FromBody] Perfil perfil)
        {
            try
            {
                _context.Add(perfil);
                await _context.SaveChangesAsync();
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, [FromBody] Perfil perfil)
        {
            try
            {
                if (id != Convert.ToInt32(perfil.Idperfil))
                {
                    return NotFound();
                }
                _context.Update(perfil);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La perfil fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)

        {
            try
            {
                var perfil = await _context.Perfils.FindAsync(id);
                if (perfil == null)
                {
                    return NotFound();
                }
                _context.Perfils.Remove(perfil);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La perfil eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
