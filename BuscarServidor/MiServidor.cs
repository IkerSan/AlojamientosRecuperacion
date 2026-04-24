using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscarServidor
{
    public static class MiServidor
    {
        /// <summary>
        /// Devuelve el nombre del servidor del ordenador en que se está ejecutando el proyecto 
        /// </summary>
        /// <param name="errorServidor">Saldrá en blanco o con mensaje de error si no se puede conectar con SqlServer</param>
        /// <returns>Devuelve el nombre del servidor</returns>
        public static string Servidor(out string errorServidor)
        {
            errorServidor = "";
            string[] servidores = { ".", ".\\SQLEXPRESS" };//, "(local)", "(local)\\SQLEXPRESS", "localhost", "localhost\\SQLEXPRESS" };
            foreach (string servidor in servidores)
            {
                try
                {
                    string cadConexion = $@"Data Source={servidor};Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=2";
                    using (SqlConnection con = new SqlConnection(cadConexion))
                    {
                        con.Open();
                        errorServidor = "";
                        return servidor; // Ha podido conectar con SqlServer
                    }
                }
                catch (Exception exc)
                {
                    errorServidor = exc.Message; // NO ha podido conectar, continúa buscando
                }
            }
            errorServidor = "No era ninguno???";
            return "";
        }
    }
}
