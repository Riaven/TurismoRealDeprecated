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
    public static class CargoEmpleadoController
    {

        static OracleConnection conn = null;
        static List<CargoEmpleado> cargos = new List<CargoEmpleado>();
        public static List<CargoEmpleado> ListarCargoEmpleado()
        {
            try
            {
                conn = ConexionBD.AbrirConexion(); // creamos la conexión con la BD
                //buscar la función
                OracleCommand cmd = new OracleCommand("FN_LISTAR_CARGO_EMPLEADO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter lista_cargo = new OracleParameter();
                lista_cargo.ParameterName = "CUR_LISTAR_CARGO_EMPLEADO";
                lista_cargo.OracleDbType = OracleDbType.RefCursor;
                lista_cargo.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(lista_cargo);

                cmd.ExecuteNonQuery();

                //rescatando la data
                OracleDataReader lector = ((OracleRefCursor)lista_cargo.Value).GetDataReader();

                while (lector.Read())
                {
                    CargoEmpleado cargo_emp = new CargoEmpleado();
                    cargo_emp.Id_cargo = lector.GetInt32(0);
                    cargo_emp.Descripcion = lector.GetString(1);

                    cargos.Add(cargo_emp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Me caí we en cargar la lista de cargos de empleado {ex}");
            }
            return cargos;
        }
    }
}
