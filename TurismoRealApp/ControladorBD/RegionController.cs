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
    public static class RegionController
    {
        static OracleConnection conn = null;
        static List<Region> regiones = new List<Region>();

        public static List<Region> ListarRegion()
        {
            try
            {
                conn = ConexionBD.AbrirConexion(); // creamos la conexión con la BD
                //buscar la función
                OracleCommand cmd = new OracleCommand("FN_LISTAR_REGION", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter lista_region = new OracleParameter();
                lista_region.ParameterName = "CUR_LISTAR_REGION";
                lista_region.OracleDbType = OracleDbType.RefCursor;
                lista_region.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(lista_region);

                cmd.ExecuteNonQuery();

                //rescatando la data
                OracleDataReader lector = ((OracleRefCursor)lista_region.Value).GetDataReader();

                while (lector.Read())
                {
                    Region region = new Region();
                    region.Id_region = lector.GetInt32(0);
                    region.Nombre = lector.GetString(1);
                    regiones.Add(region);
                }

                cmd.Parameters.Clear();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Me caí we en cargar la lista de regiones {ex}");
            }
            
            return regiones;
        }
        
    }
}
