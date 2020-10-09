using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using Oracle.ManagedDataAccess.Types;

namespace ControladorBD
{
    public static class NacionalidadController
    {
        static OracleConnection conn = null;
        static List<Nacionalidad> nacionalidades = new List<Nacionalidad>();

        public static List<Nacionalidad> ListarNacionalidad()
        {
            try
            {
                conn = ConexionBD.AbrirConexion(); // creamos la conexión con la BD
                //buscar la función
                OracleCommand cmd = new OracleCommand("FN_LISTAR_NACIONALIDAD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter lista_nacionalidad = new OracleParameter();
                lista_nacionalidad.ParameterName = "CUR_LISTAR_NACIONALIDAD";
                lista_nacionalidad.OracleDbType = OracleDbType.RefCursor;
                lista_nacionalidad.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(lista_nacionalidad);

                cmd.ExecuteNonQuery();

                //rescatando la data
                OracleDataReader lector = ((OracleRefCursor)lista_nacionalidad.Value).GetDataReader();

                while (lector.Read())
                {
                    Nacionalidad nacionalidad = new Nacionalidad();
                    nacionalidad.Id_nacionalidad = lector.GetInt32(0);
                    nacionalidad.Descripcion = lector.GetString(1);
                    nacionalidades.Add(nacionalidad);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Me caí we en cargar la lista de nacionalidades {ex}");
            }
            conn.Close();
            return nacionalidades;
        }
    }
}
