using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using Modelo;

namespace ControladorBD
{
    //es estática para solamente llamar a los métodos sin crear instancia
    public static class ServicioExtraController
    {
        
        static OracleConnection conn = null;
        static ServicioExtra servicio_extra = null;

        //Llamada a buscar
        public static ServicioExtra BuscarServicioExtra(int id)
        {
            conn = ConexionBD.AbrirConexion(); //generar conexión
            servicio_extra = null;
            
            try
            {
                
                OracleCommand cmd = new OracleCommand("SP_BUSCAR_SERVICIO_EXTRA", conn);
                //también aplica a funciones, c# no distingue entre funciones o procedimientos.
                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada, contiene el id 
                OracleParameter id_in = new OracleParameter();
                id_in.ParameterName = "P_ID";
                id_in.OracleDbType = OracleDbType.Decimal;
                id_in.Direction = ParameterDirection.Input;
                id_in.Value = id;
                cmd.Parameters.Add(id_in);
                
                //p_id_salida, parámetro de salida, contiene el id de salida, será 0 si es que no se encontró
                OracleParameter id_out = new OracleParameter();
                id_out.ParameterName = "P_ID_SALIDA";
                id_out.OracleDbType = OracleDbType.Decimal;
                id_out.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id_out);
                
                //p_descripcion_salida, parámetro que contiene la descripcion del servicio, 
                //será 'NONE' (palabra) si es que no se encuentra 
                OracleParameter descripcion_out = new OracleParameter();
                descripcion_out.ParameterName = "P_DESCRIPCION_SALIDA";
                descripcion_out.OracleDbType = OracleDbType.Varchar2;
                descripcion_out.Size = 80;
                descripcion_out.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(descripcion_out);

                cmd.ExecuteNonQuery();

                //se arma la instancia
                servicio_extra =  new ServicioExtra(int.Parse(id_out.Value.ToString()), descripcion_out.Value.ToString());
                
            }
            catch(Exception ex)
            {
                servicio_extra = null;
                return servicio_extra;

            }
            conn.Close(); //cierra la conexión
            //return servicio_extra;
            return servicio_extra;
        }

        //Llamada a crear
        /// <summary>
        /// Crear un servicio extra
        /// </summary>
        /// <param name="id">Id a registrar</param>
        /// <param name="descripcion">Descripción a registrar</param>
        /// <returns>
        /// -1 si se tiene un problema con la base de datos
        /// >0 si es que no se pudo registrar ya que el id ya existía
        /// 0 si es que se agregó correctamente
        /// </returns>
        public static int CrearServicioExtra(int id, string descripcion)
        {
            conn = ConexionBD.AbrirConexion();
            int creado = 0;
            try
            {
                OracleCommand cmd = new OracleCommand("SP_CREAR_SERVICIO_EXTRA", conn);
                
                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_inout = new OracleParameter();
                id_inout.ParameterName = "P_ID";
                id_inout.OracleDbType = OracleDbType.Decimal;
                id_inout.Direction = ParameterDirection.InputOutput;
                id_inout.Value = id;
                cmd.Parameters.Add(id_inout);

                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter descripcion_in = new OracleParameter();
                descripcion_in.ParameterName = "P_DESCRIPCION";
                descripcion_in.OracleDbType = OracleDbType.Varchar2;
                descripcion_in.Size = 20;
                descripcion_in.Direction = ParameterDirection.Input;
                descripcion_in.Value = descripcion;
                cmd.Parameters.Add(descripcion_in);

                cmd.ExecuteNonQuery();

                creado = int.Parse(id_inout.Value.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex} - ServicioExtraController/Crear");
                creado = -1;
            }
            return creado;
        }
        //Llamada a modificar
        public static int ModificarServicioExtra(int id, string descripcion)
        {
            conn = ConexionBD.AbrirConexion();
            int modificado = 0;
            try
            {
                OracleCommand cmd = new OracleCommand("SP_MODIFICAR_SERVICIO_EXTRA", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_inout = new OracleParameter();
                id_inout.ParameterName = "P_ID";
                id_inout.OracleDbType = OracleDbType.Decimal;
                id_inout.Direction = ParameterDirection.InputOutput;
                id_inout.Value = id;
                cmd.Parameters.Add(id_inout);

                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter descripcion_in = new OracleParameter();
                descripcion_in.ParameterName = "P_DESCRIPCION";
                descripcion_in.OracleDbType = OracleDbType.Varchar2;
                descripcion_in.Size = 20;
                descripcion_in.Direction = ParameterDirection.Input;
                descripcion_in.Value = descripcion;
                cmd.Parameters.Add(descripcion_in);

                cmd.ExecuteNonQuery();

                modificado = int.Parse(id_inout.Value.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex} - ServicioExtraController/Crear");
                modificado = -1;
            }
            //-1 cuando se tenga un problema con conexionbd
            // 0 cuando no se encontró con el id solicitado, no fue posible modificar
            // x>0 cuando si encuentre, entonces es posible modificar
            return modificado;
        }

        //Llamada a eliminar
        public static int EliminarServicioExtra(int id)
        {
            conn = ConexionBD.AbrirConexion();
            int eliminado = 0;
            try
            {
                OracleCommand cmd = new OracleCommand("SP_ELIMINAR_SERVICIO_EXTRA", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_inout = new OracleParameter();
                id_inout.ParameterName = "P_ID";
                id_inout.OracleDbType = OracleDbType.Decimal;
                id_inout.Direction = ParameterDirection.InputOutput;
                id_inout.Value = id;
                cmd.Parameters.Add(id_inout);

                cmd.ExecuteNonQuery();

                eliminado = int.Parse(id_inout.Value.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex}");
                eliminado = -1;
            }
            //-1 cuando se tenga un problema con conexionbd
            // 0 cuando no se encontró con el id solicitado, no fue posible eliminar
            // x>0 cuando si encuentre, entonces es posible eliminar
            return eliminado; 
        }

    }
}
