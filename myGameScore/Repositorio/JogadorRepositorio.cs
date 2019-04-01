using Dapper;
using Dominio;
using Dominio.Dto;
using Modelo;
using Repositorio.Configuracao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repositorio
{
    public class JogadorRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JogadorModelo> Selecionar()
        {
            using (var connection = new SqlConnection(DbConnection.GetConn()))
            {
                var lista = connection.Query<JogadorModelo>($"SELECT * FROM Jogador");

                return lista;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JogadorDto SelecionarPorId(int idJogador)
        {
            using (var connection = new SqlConnection(DbConnection.GetConn()))
            {
                var obj = connection.QueryFirstOrDefault<JogadorDto>($"SELECT idJogador,nomeJogador,timeJogador,emailJogador,senhaJogador FROM Jogador where idJogador = {idJogador}");

                return obj;
            }
        }

        /// <summary>
        /// 
        /// <param name="entity"></param>
        /// <returns></returns>
        /// </summary>
        public int Inserir(Jogador entity)
        {
            using (var connection = new SqlConnection(DbConnection.GetConn()))
            {
                return connection.QuerySingle<int>($"DECLARE @idJogador int;"+
                                                    $"INSERT INTO [Jogador]"+
                                                    $"(nomeJogador,timeJogador,emailJogador,senhaJogador)"+
                                                    $"VALUES('{entity.nomeJogador}'," +
                                                            $"'{entity.timeJogador}'," +
                                                            $"'{entity.emailJogador}'," +
                                                            $"'{entity.senhaJogador}')" +
                                                            $"SET @idJogador= SCOPE_IDENTITY();" +
                                                            $"SELECT @idJogador");

                
            }
        }
    }
}
