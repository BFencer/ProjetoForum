using Microsoft.AspNetCore.Mvc;
using Forum.Models;
using System.Collections.Generic;
using System;

namespace Forum.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        Usuario Usuario = new Usuario();

        DAOUsuario DAO = new DAOUsuario();

        [HttpGet(Name = "Usuario")]
        public IEnumerable<Usuario> Get()
        {
            return DAO.Listar();
        }

        [HttpPost]

        public IActionResult CadastrarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                DAO.Cadastrar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RedirectToRoute("Usuario");
        }
    }
}