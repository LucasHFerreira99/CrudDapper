﻿using AutoMapper;
using CrudDapper.DTOs;
using CrudDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CrudDapper.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UsuarioService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<UsuarioListarDto>> BuscarUsuarioPorId(int usuarioId)
        {
            ResponseModel<UsuarioListarDto> response = new ResponseModel<UsuarioListarDto>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                //var usuarioBanco = await connection.QueryFirstAsync<Usuario>($"Select * from Usuarios Where id = {usuarioId}");
                var usuarioBanco = await connection.QueryFirstOrDefaultAsync<Usuario>("Select * from Usuarios Where id = @Id", new {Id = usuarioId});
                if(usuarioBanco == null)
                {
                    response.Status = false;
                    response.Mensagem = "Nenhum usuário localizado!";
                    return response;
                }
                var usuarioMapeado = _mapper.Map<UsuarioListarDto>(usuarioBanco);

                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuário Localizado com sucesso!";
            }
            return response;
        }

        public async Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios()
        {
            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.QueryAsync<Usuario>("select * from Usuarios");

                if (usuariosBanco.Count() == 0)
                {
                    response.Status = false;
                    response.Mensagem = "Nenhum usuário localizado!";
                    return response;
                }
                //Transformação Mapper
                var usuarioMapeado = _mapper.Map<List<UsuarioListarDto>>(usuariosBanco);

                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuários Localizados com sucesso!";
            }
            return response;
        }

        public async Task<ResponseModel<List<UsuarioListarDto>>> CriarUsuario(UsuarioCriarDto usuarioCriarDto)
        {
            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>();

            using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.ExecuteAsync("insert into Usuarios (NomeCompleto, Email, Cargo, Salario, CPF, Situacao, Senha) values (@NomeCompleto, @Email, @Cargo, @Salario, @CPF, @Situacao, @Senha)", usuarioCriarDto);

                if (usuariosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar o registro!";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);

                var usuariosMapeados = _mapper.Map<List<UsuarioListarDto>>(usuarios);

                response.Dados = usuariosMapeados;
                response.Mensagem = "Usuário criado com sucesso!";
            }
            return response;
        }


        private static async Task<IEnumerable<Usuario>> ListarUsuarios(SqlConnection connection)
        {
            return await connection.QueryAsync<Usuario>("select * from Usuarios");
        }

        public async Task<ResponseModel<List<UsuarioListarDto>>> EditarUsuario(UsuarioEditarDto usuarioEditarDto)
        {
            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.ExecuteAsync("Update Usuarios set NomeCompleto = @NomeCompleto, Email = @Email, Cargo = @Cargo, Salario = @Salario, Situacao = @Situacao, CPF = @CPF where Id = @Id", usuarioEditarDto);

                if (usuariosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar a edição!";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);

                var usuariosMapeados = _mapper.Map<List<UsuarioListarDto>>(usuarios);

                response.Dados = usuariosMapeados;
                response.Mensagem = "Usuário editado com sucesso!";
            }
            return response;
        }

        public async Task<ResponseModel<List<UsuarioListarDto>>> DeletarUsuario(int usuarioId)
        {
            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.ExecuteAsync($"Delete from Usuarios where Id = @Id", new { Id = usuarioId });
                if (usuariosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao deletar!";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);

                var usuariosMapeados = _mapper.Map<List<UsuarioListarDto>>(usuarios);

                response.Dados = usuariosMapeados;
                response.Mensagem = "Usuário deletado com sucesso!";
            }
            return response;
        }
    }
}
