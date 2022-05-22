using Compras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly SistemaComprasBADContext _ctx;
        public CategoriasController( SistemaComprasBADContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        public IEnumerable<Categorium> GetTest()
        {
            return _ctx.Categoria.ToList();
        }

        [HttpGet]
        [Route("{Id}")]
       
        public async Task<IActionResult> GetCategoriaById(int Id)
        {
            try
            {
                return Ok(await _ctx.Categoria.Where(x => x.Idcategoria == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

}
