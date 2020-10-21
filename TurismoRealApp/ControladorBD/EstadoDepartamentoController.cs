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
    public static class EstadoDepartamentoController
    {
        static OracleConnection conn = null;
        static List<EstadoDepartamento> estados_depa = new List<EstadoDepartamento>();
        public static List<EstadoDepartamento> ListarEstadoDepartamento()
        {
            try
            {
                conn = ConexionBD.AbrirConexion(); // creamos la conexión con la BD
                //buscar la función
                OracleCommand cmd = new OracleCommand("FN_LISTAR_ESTADO_DEPARTAMENTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter lista_est_depa = new OracleParameter();
                lista_est_depa.ParameterName = "CUR_LISTAR_ESTADO_DEPARTAMENTO";
                lista_est_depa.OracleDbType = OracleDbType.RefCursor;
                lista_est_depa.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(lista_est_depa);

                cmd.ExecuteNonQuery();

                //rescatando la data
                OracleDataReader lector = ((OracleRefCursor)lista_est_depa.Value).GetDataReader();

                while (lector.Read())
                {
                    EstadoDepartamento esta_depa = new EstadoDepartamento();
                    esta_depa.Id_estado_departamento = lector.GetInt32(0);
                    esta_depa.Descripcion = lector.GetString(1);

                    estados_depa.Add(esta_depa);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Me caí we en cargar la lista de estados de departamento {ex}");
            }
            return estados_depa;
        }

        public static List<EstadoDepartamento> BuscarEstadoDepa(int id)
        {
            List<EstadoDepartamento> estados_depa = ListarEstadoDepartamento();
            if (estados_depa != null)
            {
               return estados_depa.Where(est => (est.Id_estado_departamento == id)).ToList();
            }
            return estados_depa;
        }
    }
}
