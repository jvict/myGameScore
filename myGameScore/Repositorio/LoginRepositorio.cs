using Dapper;
using Dominio.Dto;
using Modelo;
using Repositorio.Configuracao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositorio
{
    public class LoginRepositorio
    {
        ///<sumary>
        ///
        ///</sumary>
        ///<returns></returns>
        ///
        public IEnumerable<LoginDto> SelecionarLogin(string emailJogador, string senhaJogador)
        {
            using (var connection = new SqlConnection(DbConnection.GetConn()))
            {
                var result = connection.QueryFirstOrDefault<LoginDto>($"SELECT emailJogador FROM Jogador where emailJogador = '{emailJogador}' and senhaJogador = '{senhaJogador}'");
                yield return result;
            }
        }
    }
}
