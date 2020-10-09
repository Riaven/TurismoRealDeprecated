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
        public static Departamento BuscarDepartamento(int id)
        {
            List<Departamento> departamentos = (from departamento in ListarDepartamento() where departamento.Id_departamento == id select departamento).ToList();
            return departamentos[0];
        }

        //método crear
        public static int CrearDepartamento( int id_departamento, string direccion, int numero, int precio, string m_cuadrados, int banios, string descripcion, int cantidad_habitacion, EstadoDepartamento estado_departamento, Region region, Comuna comuna, int inventario, string funcionario, ServicioExtra servicio_extra)
        {

            conn = ConexionBD.AbrirConexion();
            int creado = 0;
            
            try
            {
                OracleCommand cmd = new OracleCommand("SP_CREAR_DEPARTAMENTO", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_inout = new OracleParameter();
                id_inout.ParameterName = "P_ID";
                id_inout.OracleDbType = OracleDbType.Decimal;
                id_inout.Direction = ParameterDirection.InputOutput;
                id_inout.Value = id_departamento;
                cmd.Parameters.Add(id_inout);

                //direccion
                OracleParameter direccion_in = new OracleParameter();
                direccion_in.ParameterName = "P_DIRECCION";
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
                m_cuadrados_in.OracleDbType = OracleDbType.Varchar2;
                m_cuadrados_in.Size = 20;
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
                descripcion_in.Size = 50;
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
                estado_in.Value = 1;
                cmd.Parameters.Add(estado_in);

                //region
                OracleParameter region_in = new OracleParameter();
                region_in.ParameterName = "P_REGION";
                region_in.OracleDbType = OracleDbType.Int32;
                region_in.Direction = ParameterDirection.Input;
                region_in.Value = region.Id_region;
                cmd.Parameters.Add(region_in);


                //comuna
                OracleParameter comuna_in = new OracleParameter();
                comuna_in.ParameterName = "P_COMUNA";
                comuna_in.OracleDbType = OracleDbType.Int32;
                comuna_in.Direction = ParameterDirection.Input;
                comuna_in.Value = comuna.Id_comuna;
                cmd.Parameters.Add(comuna_in);

                //inventario
                OracleParameter inventario_in = new OracleParameter();
                inventario_in.ParameterName = "P_INVENTARIO";
                inventario_in.OracleDbType = OracleDbType.Int32;
                inventario_in.Direction = ParameterDirection.Input;
                inventario_in.Value = 1;
                cmd.Parameters.Add(inventario_in);

                //funcionario
                OracleParameter funcionario_in = new OracleParameter();
                funcionario_in.ParameterName = "P_FUNCIONARIO";
                funcionario_in.OracleDbType = OracleDbType.Int32;
                funcionario_in.Direction = ParameterDirection.Input;
                funcionario_in.Value = 1;
                cmd.Parameters.Add(funcionario_in);

                //servicio extra
                OracleParameter servicio_extra_in = new OracleParameter();
                servicio_extra_in.ParameterName = "P_SERVICIO_EXTRA";
                servicio_extra_in.OracleDbType = OracleDbType.Int32;
                servicio_extra_in.Direction = ParameterDirection.Input;
                servicio_extra_in.Value = servicio_extra.Id_servicio_extra;
                cmd.Parameters.Add(servicio_extra_in);

                cmd.ExecuteNonQuery();

                creado = int.Parse(id_inout.Value.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex} - DepartamentoController/Crear");
                creado = -1;
            }
            conn.Close();
            return creado;
        }

        //método eliminar
        public static int EliminarDepartamento(int id)
        {
            conn = ConexionBD.AbrirConexion();
            int eliminado = 0;
            try
            {
                OracleCommand cmd = new OracleCommand("SP_ELIMINAR_DEPARTAMENTO", conn);

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
            conn.Close();
            return eliminado;
        }
        //método modificar

        public static int ModificarDepartamento(int id_departamento, string direccion, int numero, int precio, string m_cuadrados, int banios, string descripcion, int cantidad_habitacion, EstadoDepartamento estado_departamento, Region region, Comuna comuna, int inventario, string funcionario, ServicioExtra servicio_extra)
        {

            conn = ConexionBD.AbrirConexion();
            int modificado = 0;
            try
            {
                OracleCommand cmd = new OracleCommand("SP_MODIFICAR_DEPARTAMENTO", conn);

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
                direccion_in.ParameterName = "P_DIRECCION";
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
                m_cuadrados_in.OracleDbType = OracleDbType.Varchar2;
                m_cuadrados_in.Size = 20;
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
                descripcion_in.Size = 50;
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
                estado_in.Value = 1;
                cmd.Parameters.Add(estado_in);

                //region
                OracleParameter region_in = new OracleParameter();
                region_in.ParameterName = "P_REGION";
                region_in.OracleDbType = OracleDbType.Int32;
                region_in.Direction = ParameterDirection.Input;
                region_in.Value = region.Id_region;
                cmd.Parameters.Add(region_in);


                //comuna
                OracleParameter comuna_in = new OracleParameter();
                comuna_in.ParameterName = "P_COMUNA";
                comuna_in.OracleDbType = OracleDbType.Int32;
                comuna_in.Direction = ParameterDirection.Input;
                comuna_in.Value = comuna.Id_comuna;
                cmd.Parameters.Add(comuna_in);

                //inventario
                OracleParameter inventario_in = new OracleParameter();
                inventario_in.ParameterName = "P_INVENTARIO";
                inventario_in.OracleDbType = OracleDbType.Int32;
                inventario_in.Direction = ParameterDirection.Input;
                inventario_in.Value = 1;
                cmd.Parameters.Add(inventario_in);

                //funcionario
                OracleParameter funcionario_in = new OracleParameter();
                funcionario_in.ParameterName = "P_FUNCIONARIO";
                funcionario_in.OracleDbType = OracleDbType.Int32;
                funcionario_in.Direction = ParameterDirection.Input;
                funcionario_in.Value = 1;
                cmd.Parameters.Add(funcionario_in);

                //servicio extra
                OracleParameter servicio_extra_in = new OracleParameter();
                servicio_extra_in.ParameterName = "P_SERVICIO_EXTRA";
                servicio_extra_in.OracleDbType = OracleDbType.Int32;
                servicio_extra_in.Direction = ParameterDirection.Input;
                servicio_extra_in.Value = servicio_extra.Id_servicio_extra;
                cmd.Parameters.Add(servicio_extra_in);

                cmd.ExecuteNonQuery();

                modificado = int.Parse(id_inout.Value.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex} - ServicioExtraController/Modificar");
                modificado = -1;
            }
            //-1 cuando se tenga un problema con conexionbd
            // 0 cuando no se encontró con el id solicitado, no fue posible modificar
            // x>0 cuando si encuentre, entonces es posible modificar
            conn.Close();
            return modificado;
        }

        //método listar

        public static List<Departamento> ListarDepartamento()
        {
            List<Departamento> departamentos = new List<Departamento>();
            try
            {
                conn = ConexionBD.AbrirConexion();
                //buscar la función
                OracleCommand cmd = new OracleCommand("FN_LISTAR_DEPARTAMENTO", conn);
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
                List<Region> regiones = RegionController.ListarRegion();
                List<Nacionalidad> nacionalidades = NacionalidadController.ListarNacionalidad();



                while (lector.Read())
                {
                    List<Comuna> comuna_cliente = (from comuna in comunas where comuna.Id_comuna == lector.GetInt32(10) select comuna).ToList();
                    List<Region> region_cliente = (from region in regiones where region.Id_region == lector.GetInt32(11) select region).ToList();
                    List<Nacionalidad> nacionalidad_cliente = (from nacionalidad in nacionalidades where nacionalidad.Id_nacionalidad == lector.GetInt32(12) select nacionalidad).ToList();

                    Cliente cliente = new Cliente();
                    cliente.Id_cliente = lector.GetInt32(0);
                    cliente.Rut = lector.GetString(1);
                    cliente.Nombre = lector.GetString(2);
                    cliente.Primer_ape = lector.GetString(3);
                    cliente.Segundo_ape = lector.GetString(4);
                    cliente.Direccion = lector.GetString(5);
                    cliente.Telefono = lector.GetString(6);
                    cliente.Fecha_nac = lector.GetDateTime(7);
                    cliente.Correo = lector.GetString(8);
                    cliente.Frecuente = lector.GetInt32(9);
                    cliente.Comuna = comuna_cliente[0];
                    cliente.Region = region_cliente[0];
                    cliente.Nacionalidad = nacionalidad_cliente[0];
                    //departamentos.Add(cliente);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema : {ex}");
            }
            return departamentos;
        }

    }
}
