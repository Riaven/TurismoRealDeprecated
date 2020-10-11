using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Empleado
    {
        private int _id_empleado;
        private string _rut_func;
        private string _nombre_func;
        private string _primer_ape_func;
        private string _segundo_ape_func;
        private DateTime _fecha_nac_func;
        private string _direccion;
        private string _telefono;
        private string _correo;
        private int _sueldo;
        private DateTime _fecha_contrato;
        private CargoEmpleado _cargo_empleado;
        private Nacionalidad _nacionalidad;

        public Empleado()
        {
             
        }

        public Empleado(int id_empleado, string rut_func, string nombre_func, string primer_ape_func, string segundo_ape_func, DateTime fecha_nac_func, string direccion, string telefono, string correo, int sueldo, DateTime fecha_contrato, CargoEmpleado cargo_empleado, Nacionalidad nacionalidad)
        {
            Id_empleado = id_empleado;
            Rut_func = rut_func;
            Nombre_func = nombre_func;
            Primer_ape_func = primer_ape_func;
            Segundo_ape_func = segundo_ape_func;
            Fecha_nac_func = fecha_nac_func;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            Sueldo = sueldo;
            Fecha_contrato = fecha_contrato;
            Cargo_empleado = cargo_empleado;
            Nacionalidad = nacionalidad;
        }

        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public string Rut_func { get => _rut_func; set => _rut_func = value; }
        public string Nombre_func { get => _nombre_func; set => _nombre_func = value; }
        public string Primer_ape_func { get => _primer_ape_func; set => _primer_ape_func = value; }
        public string Segundo_ape_func { get => _segundo_ape_func; set => _segundo_ape_func = value; }
        public DateTime Fecha_nac_func { get => _fecha_nac_func; set => _fecha_nac_func = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public int Sueldo { get => _sueldo; set => _sueldo = value; }
        public DateTime Fecha_contrato { get => _fecha_contrato; set => _fecha_contrato = value; }
        public CargoEmpleado Cargo_empleado { get => _cargo_empleado; set => _cargo_empleado = value; }
        public Nacionalidad Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
    }
}
