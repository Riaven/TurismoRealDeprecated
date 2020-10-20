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
        private int _rut;
        private int _dv; // cambiar dv a string o char
        private string _nombre;
        private string _primer_ape;
        private string _segundo_ape;
        private string _correo;
        private DateTime _fecha_nac;
        private string _direccion;
        private int _telefono;
        private int _sueldo;
        private DateTime _fecha_contrato;
        private CargoEmpleado _cargo_empleado;
        private Nacionalidad _nacionalidad;

        public Empleado()
        {
             
        }

        public Empleado(int id_empleado, int rut, int dv, string nombre, string primer_ape, string segundo_ape, string correo, DateTime fecha_nac, string direccion, int telefono, int sueldo, DateTime fecha_contrato, CargoEmpleado cargo_empleado, Nacionalidad nacionalidad)
        {
            Id_empleado = id_empleado;
            Rut = rut;
            Dv = dv;
            Nombre = nombre;
            Primer_ape = primer_ape;
            Segundo_ape = segundo_ape;
            Correo = correo;
            Fecha_nac = fecha_nac;
            Direccion = direccion;
            Telefono = telefono;
            Sueldo = sueldo;
            Fecha_contrato = fecha_contrato;
            Cargo_empleado = cargo_empleado;
            Nacionalidad = nacionalidad;
        }

        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public int Rut { get => _rut; set => _rut = value; }
        public int Dv { get => _dv; set => _dv = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Primer_ape { get => _primer_ape; set => _primer_ape = value; }
        public string Segundo_ape { get => _segundo_ape; set => _segundo_ape = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public DateTime Fecha_nac { get => _fecha_nac; set => _fecha_nac = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public int Telefono { get => _telefono; set => _telefono = value; }
        public int Sueldo { get => _sueldo; set => _sueldo = value; }
        public DateTime Fecha_contrato { get => _fecha_contrato; set => _fecha_contrato = value; }
        public CargoEmpleado Cargo_empleado { get => _cargo_empleado; set => _cargo_empleado = value; }
        public Nacionalidad Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
    }
}
