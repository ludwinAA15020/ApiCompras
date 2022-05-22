using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Compras.Models;
using System.Linq;
using System.Collections.Generic;

namespace SistemaComprasBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly SistemaComprasBADContext _context;
        public UsuarioController(SistemaComprasBADContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsuario()
        {
            try
            {
            //    var listusuario = await _context.Usuarios.ToListAsync();
              // var lis= _context.Usuarios.Where(x => x.UserId == id).FirstOrDefaultAsync();



                List<UserDTo> lista = await (from Usuario in _context.Usuarios
                               join role in _context.Roles
                               on Usuario.Idrol equals role.Idrol
                               select new UserDTo
                               {
                                   UserId = Usuario.Idusuario,
                                //   RoleId = role.Idrol,
                                   Email = Usuario.Correo,
                                   NombreUsuario = Usuario.Nombreusuario,
                                   RoleName = role.Nombrerol,   
                               }).ToListAsync();
              




                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetUsuarioById(int Id)
        {
            try
            {
                return Ok(await _context.Usuarios.Where(x => x.Idusuario == Id).FirstOrDefaultAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteUser(int id)

        {
            try
            {
                var user = await _context.Usuarios.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] Usuario user)
        {
            try
            {
                SHA256Managed sha = new SHA256Managed();
                string pass = user.Contra;
                byte[] dataNoEncrypted = Encoding.Default.GetBytes(pass);
                byte[] dataEncrypted = sha.ComputeHash(dataNoEncrypted);
                string keyEncrypted = BitConverter.ToString(dataEncrypted).Replace("-", "");
                user.Contra = keyEncrypted;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(int id, [FromBody] Usuario user)
        {
            try
            {
                if (id != Convert.ToInt32(user.Idusuario))
                {
                    return NotFound();
                }
                _context.Update(user);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El Usuario fue actualizado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("login/{user}/{pass}")]
        public async Task<Usuario> loginUser(string user, string pass)
        {
            try
            {
                // return Ok(await _User.login(user, pass));
                SHA256Managed sha = new SHA256Managed();
                byte[] dataNoEncrypted = Encoding.Default.GetBytes(pass);
                byte[] dataEncrypted = sha.ComputeHash(dataNoEncrypted);
                string keyEncrypted = BitConverter.ToString(dataEncrypted).Replace("-", "");
                var logUser = await _context.Usuarios.Where(x => x.Contra == keyEncrypted && x.Nombreusuario == user).FirstOrDefaultAsync();
                if (logUser != null)
                {
                    return logUser;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


       





    }
}
