﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using Modelo;
using System.Security.Cryptography;

namespace ControladorBD
{
    public static class ClienteController
    {
        static OracleConnection conn = null;
        static Cliente cliente = null;


        //método buscar
        //FALTA AGREGAR BUSCAR POR NOMBRE O RUT
        public static Cliente BuscarCliente(int id)
        {
            if(ListarCliente() != null)
            {
                List<Cliente> clientes = (from cliente in ListarCliente() where cliente.Id_cliente == id select cliente).ToList();
                return clientes.Count > 0 ? clientes[0] : null;
            }
            else
            {
                Console.WriteLine("Lista de clientes vacía");
                return null;                
            }
            
        }

        //método crear
        public static int CrearCliente(int id_cliente, string rut, string nombre, string primer_ape, string segundo_ape, string direccion, string telefono, DateTime fecha_nac, string correo, int frecuente, Comuna comuna, Region region, Nacionalidad nacionalidad)
        {
            conn = ConexionBD.AbrirConexion();
            int creado = 0;
            OracleCommand cmd = null;
            try
            {
                cmd = new OracleCommand("SP_CREAR_CLIENTE", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_inout = new OracleParameter();
                id_inout.ParameterName = "P_ID";
                id_inout.OracleDbType = OracleDbType.Decimal;
                id_inout.Direction = ParameterDirection.Input;
                id_inout.Value = id_cliente;
                cmd.Parameters.Add(id_inout);

                //rut
                OracleParameter rut_in = new OracleParameter();
                rut_in.ParameterName = "P_RUT";
                rut_in.OracleDbType = OracleDbType.Varchar2;
                rut_in.Size = 10;
                rut_in.Direction = ParameterDirection.Input;
                rut_in.Value = rut;
                cmd.Parameters.Add(rut_in);

                //nombre
                OracleParameter nombre_in = new OracleParameter();
                nombre_in.ParameterName = "P_NOMBRE";
                nombre_in.OracleDbType = OracleDbType.Varchar2;
                nombre_in.Size = 20;
                nombre_in.Direction = ParameterDirection.Input;
                nombre_in.Value = nombre;
                cmd.Parameters.Add(nombre_in);


                //primer_ape
                OracleParameter primer_ape_in = new OracleParameter();
                primer_ape_in.ParameterName = "P_PRIMER_APE";
                primer_ape_in.OracleDbType = OracleDbType.Varchar2;
                primer_ape_in.Size = 40;
                primer_ape_in.Direction = ParameterDirection.Input;
                primer_ape_in.Value = primer_ape;
                cmd.Parameters.Add(primer_ape_in);


                //segundo_ape
                OracleParameter segundo_ape_in = new OracleParameter();
                segundo_ape_in.ParameterName = "P_SEGUNDO_APE";
                segundo_ape_in.OracleDbType = OracleDbType.Varchar2;
                segundo_ape_in.Size = 40;
                segundo_ape_in.Direction = ParameterDirection.Input;
                segundo_ape_in.Value = segundo_ape;
                cmd.Parameters.Add(segundo_ape_in);

                //direccion
                OracleParameter direccion_in = new OracleParameter();
                direccion_in.ParameterName = "P_DIRECCION";
                direccion_in.OracleDbType = OracleDbType.Varchar2;
                direccion_in.Size = 60;
                direccion_in.Direction = ParameterDirection.Input;
                direccion_in.Value = direccion;
                cmd.Parameters.Add(direccion_in);

                //telefono
                OracleParameter telefono_in = new OracleParameter();
                telefono_in.ParameterName = "P_TELEFONO";
                telefono_in.OracleDbType = OracleDbType.Varchar2;
                telefono_in.Size = 15;
                telefono_in.Direction = ParameterDirection.Input;
                telefono_in.Value = telefono;
                cmd.Parameters.Add(telefono_in);


                //fecha_nac
                OracleParameter fecha_nac_in = new OracleParameter();
                fecha_nac_in.ParameterName = "P_TELEFONO";
                fecha_nac_in.OracleDbType = OracleDbType.Date;
                fecha_nac_in.Direction = ParameterDirection.Input;
                fecha_nac_in.Value = fecha_nac;
                cmd.Parameters.Add(fecha_nac_in);

                //correo
                OracleParameter correo_in = new OracleParameter();
                correo_in.ParameterName = "P_CORREO";
                correo_in.OracleDbType = OracleDbType.Varchar2;
                correo_in.Size = 30;
                correo_in.Direction = ParameterDirection.Input;
                correo_in.Value = correo;
                cmd.Parameters.Add(correo_in);

                //frecuente
                OracleParameter frecuente_in = new OracleParameter();
                frecuente_in.ParameterName = "P_FRECUENTE";
                frecuente_in.OracleDbType = OracleDbType.Int32;
                frecuente_in.Direction = ParameterDirection.Input;
                frecuente_in.Value = frecuente;
                cmd.Parameters.Add(frecuente_in);

                //id_comuna
                OracleParameter comuna_in = new OracleParameter();
                comuna_in.ParameterName = "P_COMUNA";
                comuna_in.OracleDbType = OracleDbType.Int32;
                comuna_in.Direction = ParameterDirection.Input;
                comuna_in.Value = comuna.Id_comuna;
                cmd.Parameters.Add(comuna_in);

                //id_region
                OracleParameter region_in = new OracleParameter();
                region_in.ParameterName = "P_REGION";
                region_in.OracleDbType = OracleDbType.Int32;
                region_in.Direction = ParameterDirection.Input;
                region_in.Value = region.Id_region;
                cmd.Parameters.Add(region_in);

                //id_nacionalidad
                OracleParameter nacionalidad_in = new OracleParameter();
                nacionalidad_in.ParameterName = "P_NACIONALIDAD";
                nacionalidad_in.OracleDbType = OracleDbType.Int32;
                nacionalidad_in.Direction = ParameterDirection.Input;
                nacionalidad_in.Value = nacionalidad.Id_nacionalidad;
                cmd.Parameters.Add(nacionalidad_in);

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
                Console.WriteLine($"Houston, tenemos un problema : {ex} - ServicioExtraController/Crear");
                creado = -1;
            }
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            return creado;
        }

        //método eliminar
        public static int EliminarCliente(int id)
        {
            conn = ConexionBD.AbrirConexion();
            int eliminado = 0;
            OracleCommand cmd = null;
            try
            {
                cmd = new OracleCommand("SP_ELIMINAR_CLIENTE", conn);

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
            // 0 cuando ninguna fila ha sido afectada
            // 1 cuando una fila ha sido afectada
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            return eliminado;
        }
        //método modificar

        public static int ModificarCliente(int id_cliente, string rut, string nombre, string primer_ape, string segundo_ape, string direccion, string telefono, DateTime fecha_nac, string correo, int frecuente, Comuna comuna, Region region, Nacionalidad nacionalidad)
        {

            conn = ConexionBD.AbrirConexion();
            int modificado = 0;
            OracleCommand cmd = null;
            try
            {
                cmd = new OracleCommand("SP_MODIFICAR_CLIENTE", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                //tomando los datos
                //p_id parámetro de entrada y salida, contiene el id 
                OracleParameter id_inout = new OracleParameter();
                id_inout.ParameterName = "P_ID";
                id_inout.OracleDbType = OracleDbType.Decimal;
                id_inout.Direction = ParameterDirection.Input;
                id_inout.Value = id_cliente;
                cmd.Parameters.Add(id_inout);

                //rut
                OracleParameter rut_in = new OracleParameter();
                rut_in.ParameterName = "P_RUT";
                rut_in.OracleDbType = OracleDbType.Varchar2;
                rut_in.Size = 10;
                rut_in.Direction = ParameterDirection.Input;
                rut_in.Value = rut;
                cmd.Parameters.Add(rut_in);

                //nombre
                OracleParameter nombre_in = new OracleParameter();
                nombre_in.ParameterName = "P_NOMBRE";
                nombre_in.OracleDbType = OracleDbType.Varchar2;
                nombre_in.Size = 20;
                nombre_in.Direction = ParameterDirection.Input;
                nombre_in.Value = nombre;
                cmd.Parameters.Add(nombre_in);


                //primer_ape
                OracleParameter primer_ape_in = new OracleParameter();
                primer_ape_in.ParameterName = "P_PRIMER_APE";
                primer_ape_in.OracleDbType = OracleDbType.Varchar2;
                primer_ape_in.Size = 40;
                primer_ape_in.Direction = ParameterDirection.Input;
                primer_ape_in.Value = primer_ape;
                cmd.Parameters.Add(primer_ape_in);


                //segundo_ape
                OracleParameter segundo_ape_in = new OracleParameter();
                segundo_ape_in.ParameterName = "P_SEGUNDO_APE";
                segundo_ape_in.OracleDbType = OracleDbType.Varchar2;
                segundo_ape_in.Size = 40;
                segundo_ape_in.Direction = ParameterDirection.Input;
                segundo_ape_in.Value = segundo_ape;
                cmd.Parameters.Add(segundo_ape_in);

                //direccion
                OracleParameter direccion_in = new OracleParameter();
                direccion_in.ParameterName = "P_DIRECCION";
                direccion_in.OracleDbType = OracleDbType.Varchar2;
                direccion_in.Size = 60;
                direccion_in.Direction = ParameterDirection.Input;
                direccion_in.Value = direccion;
                cmd.Parameters.Add(direccion_in);

                //telefono
                OracleParameter telefono_in = new OracleParameter();
                telefono_in.ParameterName = "P_TELEFONO";
                telefono_in.OracleDbType = OracleDbType.Varchar2;
                telefono_in.Size = 15;
                telefono_in.Direction = ParameterDirection.Input;
                telefono_in.Value = telefono;
                cmd.Parameters.Add(telefono_in);


                //fecha_nac
                OracleParameter fecha_nac_in = new OracleParameter();
                fecha_nac_in.ParameterName = "P_FECHA_NAC";
                fecha_nac_in.OracleDbType = OracleDbType.Date;
                fecha_nac_in.Direction = ParameterDirection.Input;
                fecha_nac_in.Value = fecha_nac;
                cmd.Parameters.Add(fecha_nac_in);

                //correo
                OracleParameter correo_in = new OracleParameter();
                correo_in.ParameterName = "P_CORREO";
                correo_in.OracleDbType = OracleDbType.Varchar2;
                correo_in.Size = 30;
                correo_in.Direction = ParameterDirection.Input;
                correo_in.Value = correo;
                cmd.Parameters.Add(correo_in);

                //frecuente
                OracleParameter frecuente_in = new OracleParameter();
                frecuente_in.ParameterName = "P_FRECUENTE";
                frecuente_in.OracleDbType = OracleDbType.Int32;
                frecuente_in.Direction = ParameterDirection.Input;
                frecuente_in.Value = frecuente;
                cmd.Parameters.Add(frecuente_in);

                //id_comuna
                OracleParameter comuna_in = new OracleParameter();
                comuna_in.ParameterName = "P_COMUNA";
                comuna_in.OracleDbType = OracleDbType.Int32;
                comuna_in.Direction = ParameterDirection.Input;
                comuna_in.Value = comuna.Id_comuna;
                cmd.Parameters.Add(comuna_in);

                //id_region
                OracleParameter region_in = new OracleParameter();
                region_in.ParameterName = "P_REGION";
                region_in.OracleDbType = OracleDbType.Int32;
                region_in.Direction = ParameterDirection.Input;
                region_in.Value = region.Id_region;
                cmd.Parameters.Add(region_in);

                //id_nacionalidad
                OracleParameter nacionalidad_in = new OracleParameter();
                nacionalidad_in.ParameterName = "P_NACIONALIDAD";
                nacionalidad_in.OracleDbType = OracleDbType.Int32;
                nacionalidad_in.Direction = ParameterDirection.Input;
                nacionalidad_in.Value = nacionalidad.Id_nacionalidad;
                cmd.Parameters.Add(nacionalidad_in);

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
            //-1 cuando se tenga un problema con conexionbd
            // 0 cuando ninguna fila a sido afectada
            // 1 cuando una fila fue afectada
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            return modificado;
        }

        //método listar

        public static List<Cliente> ListarCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            OracleCommand cmd = null;
            try
            {
                conn = ConexionBD.AbrirConexion();
                //buscar la función
                cmd = new OracleCommand("FN_LISTAR_CLIENTE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter lista_cliente = new OracleParameter();
                lista_cliente.ParameterName = "CUR_LISTAR_CLIENTE";
                lista_cliente.OracleDbType = OracleDbType.RefCursor;
                lista_cliente.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(lista_cliente);

                cmd.ExecuteNonQuery();

                //rescatando la data
                OracleDataReader lector = ((OracleRefCursor)lista_cliente.Value).GetDataReader();
                //cargamos los datos externos

                //FALTARÍA AGREGAR VALIDACION EN CASO QUE ESTOS NO CARGEN
                List<Comuna> comunas = ComunaController.ListarComuna();
                List<Region> regiones = RegionController.ListarRegion();
                List<Nacionalidad> nacionalidades = NacionalidadController.ListarNacionalidad();

                while (lector.Read()) // se rescatan todos los datos
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
                    clientes.Add(cliente);
                }

                
                lector.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houston, tenemos un problema en listar cliente : {ex}");
                return null; // en caso de haber un error
            }
            cmd.Parameters.Clear();
            conn.Close();
            conn.Dispose();
            return clientes;
        }
    }
}
