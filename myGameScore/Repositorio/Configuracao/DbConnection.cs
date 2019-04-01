using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Configuracao
{
    public class DbConnection
    {
        private static string ConnectionString = "Data source=.;Initial Catalog=myGameScore;Integrated Security=true;";
        public static string GetConn()
        {
            return ConnectionString;
        }
    }
}
