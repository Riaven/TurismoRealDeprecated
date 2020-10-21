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
    public static class EmpleadoController
    {
        static OracleConnection conn = null;
        static List<Empleado> empleados = new List<Empleado>();
        public static List<Empleado> ListarEmpleado()
        {
            try
            {
                conn = ConexionBD.AbrirConexion(); // creamos la conexión con la BD
                //buscar la función
                OracleCommand cmd = new OracleCommand("FN_LISTAR_EMPLEADO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter lista_empleado = new OracleParameter();
                lista_empleado.ParameterName = "CUR_LISTAR_EMPLEADO";
                lista_empleado.OracleDbType = OracleDbType.RefCursor;
                lista_empleado.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(lista_empleado);

                cmd.ExecuteNonQuery();

                //rescatando la data
                OracleDataReader lector = ((OracleRefCursor)lista_empleado.Value).GetDataReader();

                // cargamos datos externos
                //List<CargoEmpleado> cargos_emp = CargoEmpleadoController.ListarCargoEmpleado();
                //List<Nacionalidad> nacionalidades = NacionalidadController.ListarNacionalidad();

                while (lector.Read())
                {
                    Empleado emp = new Empleado();
                    emp.Id_empleado = lector.GetInt32(0);
                    emp.Rut = lector.GetInt32(1);
                    emp.Dv = lector.GetInt32(2);
                    emp.Nombre = lector.GetString(3);
                    emp.Primer_ape = lector.GetString(4);
                    emp.Segundo_ape = lector.GetString(5);
                    emp.Correo = lector.GetString(6);
                    emp.Fecha_nac = lector.GetDateTime(7);
                    emp.Direccion = lector.GetString(8);
                    emp.Telefono = lector.GetInt32(9);
                    emp.Sueldo = lector.GetInt32(10);
                    emp.Fecha_contrato = lector.GetDateTime(11);

                    CargoEmpleado cargo = CargoEmpleadoController.BuscarCargoEmpleado(lector.GetInt32(12)).First();
                    //CargoEmpleado cargo = cargos_emp.Where(cargo_e => cargo_e.Id_cargo == ).ToList().FirstOrDefault();
                    emp.Cargo_empleado = cargo;

                    //Nacionalidad nacionalidad = nacionalidades.Where(nacion => nacion.Id_nacionalidad == lector.GetInt32(13)).ToList().FirstOrDefault();
                    Nacionalidad nacionalidad = NacionalidadController.BuscarNacionalidad(lector.GetInt32(13)).First();
                    emp.Nacionalidad = nacionalidad;
                    
                    empleados.Add(emp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Me caí we en cargar la lista de empledos{ex}");
            }
            return empleados;
        }

        public static List<Empleado> BuscarEmpleado(int id, string rut, string nombre, string apaterno)
        {
            List<Empleado> empleados = ListarEmpleado();
            if (empleados != null)
            {
                return empleados.Where(emp => (emp.Id_empleado == id)).ToList();
            }
            return empleados;
        }
    }
}
