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
    public class ProductoRequisicionController : ControllerBase
    {
        private readonly SistemaComprasBADContext _ctx;
        public ProductoRequisicionController( SistemaComprasBADContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        public IEnumerable<Productorequisicion> GetTest()
        {
            return _ctx.Productorequisicions.ToList();
        }
        [HttpGet("productosRequisicion/{Idproducto}/{idrequisicion}")]
        public async Task<IActionResult> GetProductorequisicionById(int Idproducto, int Idrequisicion)
        {
            try
            {
                var logUser = await _ctx.Productorequisicions.Where(x => x.Idproducto == Idproducto && x.Idrequisicion == Idrequisicion).FirstOrDefaultAsync();
                return Ok(logUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostproductoRequesicion([FromBody] Productorequisicion productorequisicion)
        {
            try
            {
                _ctx.Add(productorequisicion);
                await _ctx.SaveChangesAsync();
                return Ok(productorequisicion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }

}
