using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Dapper.Dto;
using CRUD_Dapper.Models;

namespace CRUD_Dapper.Services
{
    public interface IUsuarioInterface
    {

        Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios();
        Task<ResponseModel<UsuarioListarDto>> BuscarUsuarioPorId(int usuarioId);

        Task<ResponseModel<List<UsuarioListarDto>>> CriarUsuario(UsuarioCriarDto usuarioCriarDto);

        Task<ResponseModel<List<UsuarioListarDto>>> EditarUsuario(UsuarioEditarDto usuarioEditarDto);

        Task<ResponseModel<List<UsuarioListarDto>>> RemoverUsuario(int usuarioId);

    }
}