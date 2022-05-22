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
    public class PersonalClaveController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public PersonalClaveController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetPersonalClave()
        {
            try
            {
                var listpersonal = await _context.Personalclaves.ToListAsync();
                return Ok(listpersonal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CotizacionController>/5
        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GePersonalClaveById(int Id)
        {
            try
            {
                return Ok(await _context.Personalclaves.Where(x => x.Idpersonalclave == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostPersonal([FromBody] Personalclave personal)
        {
            try
            {
                _context.Add(personal);
                await _context.SaveChangesAsync();
                return Ok(personal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonal(int id, [FromBody] Personalclave personal)
        {
            try
            {
                if (id != Convert.ToInt32(personal.Idpersonalclave))
                {
                    return NotFound();
                }
                _context.Update(personal);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La Persona fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonal(int id)

        {
            try
            {
                var personal = await _context.Personalclaves.FindAsync(id);
                if (personal == null)
                {
                    return NotFound();
                }
                _context.Personalclaves.Remove(personal);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La Persona eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
