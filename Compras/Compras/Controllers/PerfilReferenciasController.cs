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
    public class PerfilReferenciasController : ControllerBase
    {
        private readonly SistemaComprasBADContext _ctx;
        public PerfilReferenciasController( SistemaComprasBADContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        public IEnumerable<Perfilreferencia> GetPerfilTReferencia()
        {
            return _ctx.Perfilreferencias.ToList();
        }
        [HttpGet("perfilReferencia/{Idperfil}/{Idreferencia}")]
        public async Task<IActionResult> GetPerfilReferenciaById(int Idperfil, int idreferencia)
        {
            try
            {
                var logUser = await _ctx.Perfilreferencias.Where(x => x.Idperfil == Idperfil && x.Idreferencia == idreferencia).FirstOrDefaultAsync();
                return Ok(logUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostperfilReferencia([FromBody] Perfilreferencia perfilReferencia)
        {
            try
            {
                _ctx.Add(perfilReferencia);
                await _ctx.SaveChangesAsync();
                return Ok(perfilReferencia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
