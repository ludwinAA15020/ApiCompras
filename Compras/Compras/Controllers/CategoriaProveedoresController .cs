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
    public class CategoriaProveedoresController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public CategoriaProveedoresController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetCatProp()
        {
            try
            {
                var listCompania = await _context.Categoriaproveedors.ToListAsync();
                return Ok(listCompania);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CotizacionController>/5
        
       [ HttpGet("categoriaProveedor/{Idproveedor}/{Idcategoria}")]
        public async Task<IActionResult> GetCategoriaProveedorById(int IdProveedor ,int idcategoria)
        {
            try
            {
                var logUser = await _context.Categoriaproveedors.Where(x => x.Idproveedores== IdProveedor && x.Idcategoria == idcategoria).FirstOrDefaultAsync();
                return Ok(logUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostpcategoriaProveedor([FromBody] Categoriaproveedor categoriaProveedor)
        {
            try
            {
                _context.Add(categoriaProveedor);
                await _context.SaveChangesAsync();
                return Ok(categoriaProveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
