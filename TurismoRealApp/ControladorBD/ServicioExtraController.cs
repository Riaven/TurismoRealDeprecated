using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using CapaAccesoDatos;

namespace ControladorBD
{
    //es estática para solamente llamar a los métodos sin crear instancia
    public static class ServicioExtraController
    {
        
        static OracleConnection conn = null;
        static ServicioExtra servicio_extra = null;

        //Llamada a buscar
        public static string BuscarServicioExtra(int id)
        {
            conn = ConexionBD.AbrirConexion();
            string nota = string.Empty;
            int i = 0;
           
            try
            {
                
                OracleCommand cmd = new OracleCommand("SP_BUSCAR_SERVICIO_EXTRA", conn);
                //también aplica a funciones, c# no distingue entre funciones o procedimientos.
                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos

                OracleParameter id_in = new OracleParameter();
                id_in.ParameterName = "P_ID";
                id_in.OracleDbType = OracleDbType.Decimal;
                id_in.Direction = ParameterDirection.Input;
                id_in.Value = id;
                cmd.Parameters.Add(id_in);
                
                OracleParameter id_out = new OracleParameter();
                id_out.ParameterName = "P_ID_SALIDA";
                id_out.OracleDbType = OracleDbType.Decimal;
                id_out.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id_out);
                
                OracleParameter descripcion_out = new OracleParameter();
                descripcion_out.ParameterName = "P_DESCRIPCION_SALIDA";
                descripcion_out.OracleDbType = OracleDbType.Varchar2;
                descripcion_out.Size = 80;
                descripcion_out.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(descripcion_out);

                cmd.ExecuteNonQuery();
                
                i = int.Parse(id_out.Value.ToString());
                
                if (int.Parse(id_out.Value.ToString()) == 0)
                {
                    nota= $"No se ha podido buscar datos devueltos id = {id_out.Value}  descripcion = {descripcion_out.Value}";
                }
                else
                {
                    nota =  $" id = {id_out.Value}  descripcion = {descripcion_out.Value}";
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error al buscar la información en la base de datos : {ex}");
                

            }
            conn.Close(); //cierra la conexión
            //return servicio_extra;
            return nota;
        }


        //Llamada a crear
        //Llamada a modificar
        //Llamada a eliminar






    }
}
