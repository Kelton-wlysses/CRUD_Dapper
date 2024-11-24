using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Dapper.Dto;
using CRUD_Dapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Dapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();
            if (usuarios.Status == false)
            {
                return NotFound(usuarios);
            }
            return Ok(usuarios);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int usuarioId)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(usuarioId);
            if (usuario.Status == false)
            {
                return NotFound(usuario);
            }
            return Ok(usuario);
        }


        //Post methods
        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioCriarDto usuarioCriarDto)
        {
            var usuarios = await _usuarioInterface.CriarUsuario(usuarioCriarDto);
            if (usuarios.Status == false)
            {
                return BadRequest(usuarios);
            }

            return Ok(usuarios);

        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(UsuarioEditarDto usuarioEditarDto)
        {
            var usuarios = await _usuarioInterface.EditarUsuario(usuarioEditarDto);
            if (usuarios.Status == false)
            {
                return BadRequest(usuarios);
            }
            return Ok(usuarios);
        }


    }
}