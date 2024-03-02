﻿using IntegrandoApi.Models;
using IntegrandoApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace IntegrandoApi.Controllers
{
    [ApiController]
    [Route("api/Usuario/")]
    public class UsuarioController : Controller
    {
        private UsuarioService Uservice;
        public UsuarioController(UsuarioService uservice)
        {
            this.Uservice = uservice;
        }
        [HttpGet]
        [Route("{usuario}/{contrasena}")]
        public ActionResult<Usuario> InicioSesion(string usuario, string contrasena)
        {
            try
            {
                return this.Uservice.ObternerUsuariaporUsuarioContrasena(usuario, contrasena);
            }
            catch (Exception) { return BadRequest("Usuario Incorrecto"); }
        }
        [HttpGet]
        [Route("{nombreusuario}")]
        public ActionResult<Usuario> ObtenerUsuario(string nombreusuario)
        {
            if (nombreusuario is null)
            {
                return BadRequest();
            }
            else
            {
                return this.Uservice.ObtenerUsuario(nombreusuario);
            }
        }
        [HttpGet]
        [Route("listarusuarios")]
        public ActionResult<List<Usuario>> ObtenerUsuarios()
        {
            return this.Uservice.ListarUsuarios();
        }
        [HttpPost]
        [Route("crearusuario")]
        public ActionResult CrearUsuario([FromBody] Usuario user)
        {
            try
            {
                if (this.Uservice.CrearUsuario(user))
                {
                    return Ok();
                }
                return Ok();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return BadRequest(); }
        }
        [HttpPut]
        [Route("modificarusuario")]
        public ActionResult ModificarUsuario([FromBody] Usuario user)
        {
            if (this.Uservice.ModificarUsuario(user.Id, user))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("eliminarusuario/{id}")]
        public ActionResult EliminarUsuario(int id)
        {
            if (this.Uservice.EliminarUsuario(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}