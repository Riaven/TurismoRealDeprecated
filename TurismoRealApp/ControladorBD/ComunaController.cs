using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace ControladorBD
{
    public  static class ComunaController
    {
        static OracleConnection conn = null;
        static List<Comuna> comunas = new List<Comuna>();
        public static List<Comuna> ListarComuna()
        {
            try
            {
                conn = ConexionBD.AbrirConexion(); // creamos la conexión con la BD
                //buscar la función
                OracleCommand cmd = new OracleCommand("FN_LISTAR_COMUNA", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter lista_comuna = new OracleParameter();
                lista_comuna.ParameterName = "CUR_LISTAR_COMUNA";
                lista_comuna.OracleDbType = OracleDbType.RefCursor;
                lista_comuna.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(lista_comuna);

                cmd.ExecuteNonQuery();

                //rescatando la data
                OracleDataReader lector = ((OracleRefCursor)lista_comuna.Value).GetDataReader();

                while (lector.Read())
                {
                    Comuna comuna = new Comuna();
                    comuna.Id_comuna = lector.GetInt32(0);
                    comuna.Nombre = lector.GetString(1);
                    comunas.Add(comuna);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Me caí we en cargar la lista de comunas {ex}");
            }
            return comunas;
        }
    }
}
