using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}