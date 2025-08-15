using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


namespace LojaNet.DAL
{
    public static class DbHelper
    {
        public static string conexao
        {
            get
            {
                return @"Data Source=DAYLES\SQLEXPRESS;
                         initial Catalog=LojaNetDb;
                         Integrated Security=true";
            }
        }

        public static int ExecuteNonQuery(string storeProcedure, params object[] parametros)
        {
            using (var cn = new SqlConnection(conexao))
            {
                using (var cmd = new SqlCommand(storeProcedure, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    PreencherPrametros(parametros, cmd);

                    cn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        private static void PreencherPrametros(object[] parametros, SqlCommand cmd)
        {
            if (parametros.Length > 0)
            {
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                }
            }
        }

        public static SqlDataReader ExecuteReader(string storeProcedure, params object[] parametros)
        {
            var cn = new SqlConnection(conexao);
            var cmd = new SqlCommand(storeProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            PreencherPrametros(parametros, cmd);

            cn.Open();
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
    }
}