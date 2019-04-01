using Dapper;
using Dominio;
using Dominio.Dto;
using Modelo;
using Modelo.ModelInput;
using Repositorio.Configuracao;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Repositorio
{
    public class PontuacaoRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PontuacaoModelo> Selecionar()
        {
            using (var connection = new SqlConnection(Configuracao.DbConnection.GetConn()))
            {
                var obj = connection.Query<PontuacaoModelo>($"SELECT * FROM pontuacao");

                return obj;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InfoModelo> SelecionarInfo()
        {
            using (var connection = new SqlConnection(Configuracao.DbConnection.GetConn()))
            {
             
                /*Pensei em deixar que o banco de dados, por meio de comendo SQL trouxe todas as informações de media de ponto, maior pontuação e ETC. 
                 * Tentando assim primeiramente realizar teste pelo swagger.        
                 * Pensei também em fazer um método para informação que precisaria ser traga do banco de dados.
                 */
                var obj = connection.Query<InfoModelo>($"select min(dataPontuacao),  max(dataPontuacao), avg(pontos) , count(dataPontuacao) , max(pontos)   from pontuacao");

                return obj;
            }
        }
       
        /// <summary>
        /// 
        /// <param name="entity"></param>
        /// <returns></returns>
        /// </summary>
        public int Inserir (Pontuacao entity)
        {
            using (var connection = new SqlConnection(Configuracao.DbConnection.GetConn()))
            {
                return connection.QuerySingle<int>($"DECLARE @idPontuacao int;" +
                                                    $"INSERT INTO [pontuacao]" +
                                                    $"(dataPontuacao,pontos)"+
                                                    $"VALUES('{entity.dataPontuacao}'," +
                                                    $"'{entity.pontos}')" +                                                   
                                                    $"SET @idPontuacao = SCOPE_IDENTITY();" +
                                                    $"SELECT @idPontuacao");
            }
        }
    }
}
