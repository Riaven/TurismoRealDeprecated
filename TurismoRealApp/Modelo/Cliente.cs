using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {
        private int _id_cliente;
        private string _rut;
        private string _nombre;
        private string _apaterno;
        private string _amaterno;
        private string _correo;
        private string _direccion;
        private int _telefono;
        private DateTime _fe_naci;
        private int _frecuente;
        private Comuna _comuna;
        private Nacionalidad _nacionalidad;
       

        public Cliente()
        {

        }

        public Cliente(int id_cliente, string rut, string nombre, string apaterno, string amaterno, string correo, string direccion, int telefono, DateTime fe_naci, int frecuente, Comuna comuna, Nacionalidad nacionalidad)
        {
            Id_cliente = id_cliente;
            Rut = rut;
            Nombre = nombre;
            Apaterno = apaterno;
            Amaterno = amaterno;
            Correo = correo;
            Direccion = direccion;
            Telefono = telefono;
            Fe_naci = fe_naci;
            Frecuente = frecuente;
            Comuna = comuna;
            Nacionalidad = nacionalidad;
        }

        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public string Rut { get => _rut; set => _rut = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apaterno { get => _apaterno; set => _apaterno = value; }
        public string Amaterno { get => _amaterno; set => _amaterno = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public int Telefono { get => _telefono; set => _telefono = value; }
        public DateTime Fe_naci { get => _fe_naci; set => _fe_naci = value; }
        public int Frecuente { get => _frecuente; set => _frecuente = value; }
        public Comuna Comuna { get => _comuna; set => _comuna = value; }
        public Nacionalidad Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
    }
}
