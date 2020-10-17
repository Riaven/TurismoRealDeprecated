using Modelo;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ControladorBD
{
    //es estática para solamente llamar a los métodos sin crear instancia
    public static class ServicioExtraController
    {
        static OracleConnection conn = null;

        //Llamada a buscar
        /*Puede retornar
         null =  no se encontró ninguna lista
         1 o + objeto =  encontrado*/
        public static List<ServicioExtra> BuscarServicioExtra(int? id, string descripcion)
        {
            List<ServicioExtra> servicios_extras = ListarServicioExtra();
            if (servicios_extras != null)
            {
                return servicios_extras.Where(servicio_extra => (String.IsNullOrEmpty(descripcion) ? true : servicio_extra.Descripcion.Contains(descripcion)) && (id == null ? true : servicio_extra.Id_servicio_extra == id)).ToList();
            }
            return servicios_extras;
        }

        //Llamada a crear

        public static int CrearServicioExtra(int id, string descripcion)
        {
            conn = ConexionBD.AbrirConexion();
            int creado = 0;
            OracleCommand cmd = null;
            try
            {
                cmd = new OracleCommand("SP_CREAR_SERVICIO_EXTRA", conn);
                //decimos que es un procedimiento/función
                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_in = new OracleParameter();
                id_in.ParameterName = "P_ID";
                id_in.OracleDbType = OracleDbType.Decimal;
                id_in.Direction = ParameterDirection.Input;
                id_in.Value = id;
                cmd.Parameters.Add(id_in);

                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter descripcion_in = new OracleParameter();
                descripcion_in.ParameterName = "P_DESCRIPCION";
                descripcion_in.OracleDbType = OracleDbType.Varchar2;
                descripcion_in.Size = 20;
                descripcion_in.Direction = ParameterDirection.Input;
                descripcion_in.Value = descripcion;
                cmd.Parameters.Add(descripcion_in);

                //retorna filas afectadas 
                OracleParameter affected_out = new OracleParameter();
                affected_out.ParameterName = "P_AFFECTED";
                affected_out.OracleDbType = OracleDbType.Int32;
                affected_out.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(affected_out);


                cmd.ExecuteNonQuery();

                creado = int.Parse(affected_out.Value.ToString());

                cmd.Parameters.Clear();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex} - ServicioExtraController/Crear");
                creado = -1;
            }
            //-1 error con la base de datos
            //0 no se modifico ninguna fila
            //1 se modifico una fila
            return creado;
        }
        //Llamada a modificar
        public static int ModificarServicioExtra(int id, string descripcion)
        {
            conn = ConexionBD.AbrirConexion();
            int modificado = 0;
            OracleCommand cmd = null;
            try
            {
                cmd = new OracleCommand("SP_MODIFICAR_SERVICIO_EXTRA", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_in = new OracleParameter();
                id_in.ParameterName = "P_ID";
                id_in.OracleDbType = OracleDbType.Decimal;
                id_in.Direction = ParameterDirection.Input;
                id_in.Value = id;
                cmd.Parameters.Add(id_in);

                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter descripcion_in = new OracleParameter();
                descripcion_in.ParameterName = "P_DESCRIPCION";
                descripcion_in.OracleDbType = OracleDbType.Varchar2;
                descripcion_in.Size = 20;
                descripcion_in.Direction = ParameterDirection.Input;
                descripcion_in.Value = descripcion;
                cmd.Parameters.Add(descripcion_in);

                OracleParameter affected_out = new OracleParameter();
                affected_out.ParameterName = "P_AFFECTED";
                affected_out.OracleDbType = OracleDbType.Int32;
                affected_out.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(affected_out);

                cmd.ExecuteNonQuery();

                modificado = int.Parse(affected_out.Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex} - ServicioExtraController/Modificar");
                modificado = -1;
            }
            //-1 cuando se tenga un problema con conexionbd
            // 0 no se modifico ninguna fila
            // 1 se modificó una fila
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            return modificado;
        }

        //Llamada a eliminar
        public static int EliminarServicioExtra(int id)
        {
            conn = ConexionBD.AbrirConexion();
            int eliminado = 0;
            OracleCommand cmd = null;
            try
            {
                cmd = new OracleCommand("SP_ELIMINAR_SERVICIO_EXTRA", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_in = new OracleParameter();
                id_in.ParameterName = "P_ID";
                id_in.OracleDbType = OracleDbType.Decimal;
                id_in.Direction = ParameterDirection.Input;
                id_in.Value = id;
                cmd.Parameters.Add(id_in);

                //retorna filas afectadas 
                OracleParameter affected_out = new OracleParameter();
                affected_out.ParameterName = "P_AFFECTED";
                affected_out.OracleDbType = OracleDbType.Int32;
                affected_out.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(affected_out);

                cmd.ExecuteNonQuery();

                eliminado = int.Parse(affected_out.Value.ToString());


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex}");
                eliminado = -1;
            }
            //-1 cuando se tenga un problema con conexionbd
            // 0 ninguna fila fue modificada
            // 1 fila modificada
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            return eliminado;
        }


        //listar clientes
        public static List<ServicioExtra> ListarServicioExtra()
        {
            List<ServicioExtra> servicios_extras = new List<ServicioExtra>();
            OracleCommand cmd = null;
            try
            {
                conn = ConexionBD.AbrirConexion();
                //buscar la función
                cmd = new OracleCommand("FN_LISTAR_SERVICIOS_EXTRA", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter lista_servicio_extra = new OracleParameter();
                lista_servicio_extra.ParameterName = "CUR_LISTAR_SERVICIO_EXTRA";
                lista_servicio_extra.OracleDbType = OracleDbType.RefCursor;
                lista_servicio_extra.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(lista_servicio_extra);

                cmd.ExecuteNonQuery();
                //tomar datos
                OracleDataReader lector = ((OracleRefCursor)lista_servicio_extra.Value).GetDataReader();
                while (lector.Read())
                {
                    ServicioExtra se = new ServicioExtra();
                    se.Id_servicio_extra = lector.GetInt32(0);
                    se.Descripcion = lector.GetString(1);

                    servicios_extras.Add(se);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tenemos un problema con listar clientes {ex}");
                return null;
            }

            return servicios_extras;
        }
    }
}
