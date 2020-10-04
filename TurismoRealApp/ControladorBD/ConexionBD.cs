using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using ControladorBD;

namespace ControladorBD
{
    public static class ConexionBD
    {
        private static OracleConnection conn = null;
        
        //abrir conexión y retorna la instancia
        public static OracleConnection AbrirConexion()
        {
            string connection_string = ConfigurationManager.ConnectionStrings["OracleBD"].ConnectionString;
            conn = new OracleConnection(connection_string);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

            }
            return conn;
        }

        
        
    }
}
