using Compras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyULibrary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly SistemaComprasBADContext _context;
        public RolesController(SistemaComprasBADContext context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var listProductos = await _context.Roles.ToListAsync();
                return Ok(listProductos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<ProductoController>/5

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetRolesById(int Id)
        {
            try
            {
                return Ok(await _context.Roles.Where(x => x.Idrol == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> PostRole([FromBody] Role role)
        {
            try
            {
                _context.Add(role);
                await _context.SaveChangesAsync();
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, [FromBody] Role role)
        {
            try
            {
                if (id != Convert.ToInt32(role.Idrol))
                {
                    return NotFound();
                }
                _context.Update(role);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El Rol fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)

        {
            try
            {
                var role = await _context.Roles.FindAsync(id);
                if (role == null)
                {
                    return NotFound();
                }
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Rol eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

