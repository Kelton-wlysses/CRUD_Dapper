using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AutoMapper;
using CRUD_Dapper.Dto;
using CRUD_Dapper.Models;
using Dapper;

namespace CRUD_Dapper.Services
{
    public class UsuarioService : IUsuarioInterface
    {

        // Injeção de Dependência
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsuarioService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }



        public async Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios()
        {

            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.QueryAsync<Usuario>("select * from Usuarios");

                if (usuariosBanco.Count() == 0)
                {
                    response.Mensagem = "Nenhum usuário localizado!";
                    response.Status = false;
                    return response;
                }

                //Transformação Mapper
                var usuarioMapeado = _mapper.Map<List<UsuarioListarDto>>(usuariosBanco);

                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuários Localizados com sucesso!";

            }

            return response;
        }

    }
}