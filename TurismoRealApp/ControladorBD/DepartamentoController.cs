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
    public static class DepartamentoController
    {
        static OracleConnection conn = null;
        static Departamento departamento = null;


        //método buscar
        //falta agregar buscar por demás atributos
        public static Departamento BuscarDepartamento(int id)
        {
            if (ListarDepartamento().Count > 0)
            {
                List<Departamento> departamentos = (from departamento in ListarDepartamento() where departamento.Id_departamento == id select departamento).ToList();

                return departamentos.Count > 0 ? departamentos[0] : null;
            }
            else
            {
                return null;
            }
        }

        //método crear
        public static int CrearDepartamento( string direccion, int numero, int precio, string m_cuadrados, int banios, string descripcion, int cantidad_habitacion, EstadoDepartamento estado_departamento,  Comuna comuna, Empleado funcionario)
        {

            conn = ConexionBD.AbrirConexion();
            int creado = 0;
            OracleCommand cmd = null;
            try
            {
                cmd = new OracleCommand("SP_CREAR_DEPARTAMENTO", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                
                //direccion
                OracleParameter direccion_in = new OracleParameter();
                direccion_in.ParameterName = "P_UBICACION";
                direccion_in.OracleDbType = OracleDbType.Varchar2;
                direccion_in.Size = 60;
                direccion_in.Direction = ParameterDirection.Input;
                direccion_in.Value = direccion;
                cmd.Parameters.Add(direccion_in);

                //numero
                OracleParameter numero_in = new OracleParameter();
                numero_in.ParameterName = "P_NUMERO";
                numero_in.OracleDbType = OracleDbType.Int32;
                numero_in.Direction = ParameterDirection.Input;
                numero_in.Value = numero;
                cmd.Parameters.Add(numero_in);


                //precio
                OracleParameter precio_in = new OracleParameter();
                precio_in.ParameterName = "P_PRECIO";
                precio_in.OracleDbType = OracleDbType.Int32;
                precio_in.Direction = ParameterDirection.Input;
                precio_in.Value = precio;
                cmd.Parameters.Add(precio_in);


                //m cuadrados
                OracleParameter m_cuadrados_in = new OracleParameter();
                m_cuadrados_in.ParameterName = "P_M_CUADRADOS";
                m_cuadrados_in.OracleDbType = OracleDbType.Int32;
                m_cuadrados_in.Direction = ParameterDirection.Input;
                m_cuadrados_in.Value = m_cuadrados;
                cmd.Parameters.Add(m_cuadrados_in);

                //BANIOS
                OracleParameter banios_in = new OracleParameter();
                banios_in.ParameterName = "P_BANIOS";
                banios_in.OracleDbType = OracleDbType.Int32;
                banios_in.Direction = ParameterDirection.Input;
                banios_in.Value = banios;
                cmd.Parameters.Add(banios_in);

                //descripcion
                OracleParameter descripcion_in = new OracleParameter();
                descripcion_in.ParameterName = "P_DESCRIPCION";
                descripcion_in.OracleDbType = OracleDbType.Varchar2;
                descripcion_in.Size = 300;
                descripcion_in.Direction = ParameterDirection.Input;
                descripcion_in.Value = descripcion;
                cmd.Parameters.Add(descripcion_in);


                //CANTIDAD HABITACION
                OracleParameter cantidad_habitacion_in = new OracleParameter();
                cantidad_habitacion_in.ParameterName = "P_CANTIDAD_HABITACION";
                cantidad_habitacion_in.OracleDbType = OracleDbType.Int32;
                cantidad_habitacion_in.Direction = ParameterDirection.Input;
                cantidad_habitacion_in.Value = cantidad_habitacion;
                cmd.Parameters.Add(cantidad_habitacion_in);

                //estado
                OracleParameter estado_in = new OracleParameter();
                estado_in.ParameterName = "P_ESTADO";
                estado_in.OracleDbType = OracleDbType.Int32;
                estado_in.Direction = ParameterDirection.Input;
                estado_in.Value = estado_departamento.Id_estado_departamento;
                cmd.Parameters.Add(estado_in);

                //funcionario
                OracleParameter funcionario_in = new OracleParameter();
                funcionario_in.ParameterName = "P_FUNCIONARIO";
                funcionario_in.OracleDbType = OracleDbType.Int32;
                funcionario_in.Direction = ParameterDirection.Input;
                funcionario_in.Value = funcionario.Id_empleado;
                cmd.Parameters.Add(funcionario_in);

                //comuna
                OracleParameter comuna_in = new OracleParameter();
                comuna_in.ParameterName = "P_COMUNA";
                comuna_in.OracleDbType = OracleDbType.Int32;
                comuna_in.Direction = ParameterDirection.Input;
                comuna_in.Value = comuna.Id_comuna;
                cmd.Parameters.Add(comuna_in);

                //retorna filas afectadas 
                OracleParameter affected_out = new OracleParameter();
                affected_out.ParameterName = "P_AFFECTED";
                affected_out.OracleDbType = OracleDbType.Int32;
                affected_out.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(affected_out);

                cmd.ExecuteNonQuery();

                creado = int.Parse(affected_out.Value.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex} - DepartamentoController/Crear");
                creado = -1;
            }
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            return creado;
        }

        //método eliminar
        public static int EliminarDepartamento(int id)
        {
            conn = ConexionBD.AbrirConexion();
            OracleCommand cmd = null;
            int eliminado = 0;
            try
            {
                cmd = new OracleCommand("SP_ELIMINAR_DEPARTAMENTO", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_inout = new OracleParameter();
                id_inout.ParameterName = "P_ID";
                id_inout.OracleDbType = OracleDbType.Decimal;
                id_inout.Direction = ParameterDirection.Input;
                id_inout.Value = id;
                cmd.Parameters.Add(id_inout);

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
            // 0 fila no afectada
            // 1 fila afectada
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            return eliminado;
        }
        //método modificar

        public static int ModificarDepartamento(int id_departamento, string direccion, int numero, int precio, string m_cuadrados, int banios, string descripcion, int cantidad_habitacion, EstadoDepartamento estado_departamento, Comuna comuna, Empleado funcionario)
        {

            conn = ConexionBD.AbrirConexion();
            int modificado = 0;
            OracleCommand cmd = null;
            try
            {
                cmd = new OracleCommand("SP_MODIFICAR_DEPARTAMENTO", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_inout = new OracleParameter();
                id_inout.ParameterName = "P_ID";
                id_inout.OracleDbType = OracleDbType.Decimal;
                id_inout.Direction = ParameterDirection.InputOutput;
                id_inout.Value = id_departamento;
                cmd.Parameters.Add(id_inout);

                //direccion
                OracleParameter direccion_in = new OracleParameter();
                direccion_in.ParameterName = "P_UBICACION";
                direccion_in.OracleDbType = OracleDbType.Varchar2;
                direccion_in.Size = 60;
                direccion_in.Direction = ParameterDirection.Input;
                direccion_in.Value = direccion;
                cmd.Parameters.Add(direccion_in);

                //numero
                OracleParameter numero_in = new OracleParameter();
                numero_in.ParameterName = "P_NUMERO";
                numero_in.OracleDbType = OracleDbType.Int32;
                numero_in.Direction = ParameterDirection.Input;
                numero_in.Value = numero;
                cmd.Parameters.Add(numero_in);


                //precio
                OracleParameter precio_in = new OracleParameter();
                precio_in.ParameterName = "P_PRECIO";
                precio_in.OracleDbType = OracleDbType.Int32;
                precio_in.Direction = ParameterDirection.Input;
                precio_in.Value = precio;
                cmd.Parameters.Add(precio_in);


                //m cuadrados
                OracleParameter m_cuadrados_in = new OracleParameter();
                m_cuadrados_in.ParameterName = "P_M_CUADRADOS";
                m_cuadrados_in.OracleDbType = OracleDbType.Int32;
                m_cuadrados_in.Direction = ParameterDirection.Input;
                m_cuadrados_in.Value = m_cuadrados;
                cmd.Parameters.Add(m_cuadrados_in);

                //BANIOS
                OracleParameter banios_in = new OracleParameter();
                banios_in.ParameterName = "P_BANIOS";
                banios_in.OracleDbType = OracleDbType.Int32;
                banios_in.Direction = ParameterDirection.Input;
                banios_in.Value = banios;
                cmd.Parameters.Add(banios_in);

                //descripcion
                OracleParameter descripcion_in = new OracleParameter();
                descripcion_in.ParameterName = "P_DESCRIPCION";
                descripcion_in.OracleDbType = OracleDbType.Varchar2;
                descripcion_in.Size = 300;
                descripcion_in.Direction = ParameterDirection.Input;
                descripcion_in.Value = descripcion;
                cmd.Parameters.Add(descripcion_in);


                //CANTIDAD HABITACION
                OracleParameter cantidad_habitacion_in = new OracleParameter();
                cantidad_habitacion_in.ParameterName = "P_CANTIDAD_HABITACION";
                cantidad_habitacion_in.OracleDbType = OracleDbType.Int32;
                cantidad_habitacion_in.Direction = ParameterDirection.Input;
                cantidad_habitacion_in.Value = cantidad_habitacion;
                cmd.Parameters.Add(cantidad_habitacion_in);

                //estado
                OracleParameter estado_in = new OracleParameter();
                estado_in.ParameterName = "P_ESTADO";
                estado_in.OracleDbType = OracleDbType.Int32;
                estado_in.Direction = ParameterDirection.Input;
                estado_in.Value = estado_departamento.Id_estado_departamento;
                cmd.Parameters.Add(estado_in);

                //funcionario
                OracleParameter funcionario_in = new OracleParameter();
                funcionario_in.ParameterName = "P_FUNCIONARIO";
                funcionario_in.OracleDbType = OracleDbType.Int32;
                funcionario_in.Direction = ParameterDirection.Input;
                funcionario_in.Value = funcionario.Id_empleado;
                cmd.Parameters.Add(funcionario_in);

                //comuna
                OracleParameter comuna_in = new OracleParameter();
                comuna_in.ParameterName = "P_COMUNA";
                comuna_in.OracleDbType = OracleDbType.Int32;
                comuna_in.Direction = ParameterDirection.Input;
                comuna_in.Value = comuna.Id_comuna;
                cmd.Parameters.Add(comuna_in);

                //retorna filas afectadas 
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
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            //-1 cuando se tenga un problema con conexionbd
            // 0 ninguna fila fue afectada
            // 1 cuando la fila ha sido afectada
            return modificado;
        }

        //método listar

        public static List<Departamento> ListarDepartamento()
        {
            List<Departamento> departamentos = new List<Departamento>();
            OracleCommand cmd = null;
            try
            {
                conn = ConexionBD.AbrirConexion();
                //buscar la función
                cmd = new OracleCommand("FN_LISTAR_DEPARTAMENTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter lista_departamento = new OracleParameter();
                lista_departamento.ParameterName = "CUR_LISTAR_DEPARTAMENTO";
                lista_departamento.OracleDbType = OracleDbType.RefCursor;
                lista_departamento.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(lista_departamento);

                cmd.ExecuteNonQuery();

                //rescatando la data
                OracleDataReader lector = ((OracleRefCursor)lista_departamento.Value).GetDataReader();
                //cargamos los datos externos
                List<Comuna> comunas = ComunaController.ListarComuna();
                
                //estado_departamento



                while (lector.Read())
                {
                    //TODO
                    //departamentos.Add(cliente);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex}");
            }
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            return departamentos;
        }

    }
}
