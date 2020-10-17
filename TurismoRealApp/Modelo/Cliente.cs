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
        private string _primer_ape;
        private string _segundo_ape;
        private string _direccion;
        private string _telefono;
        private DateTime _fecha_nac;
        private string _correo;
        private int _frecuente;
        private Comuna _comuna;
        private Region _region;
        private Nacionalidad _nacionalidad;

        public Cliente()
        {

        }

        public Cliente(int id_cliente, string rut, string nombre, string primer_ape, string segundo_ape, string direccion, string telefono, DateTime fecha_nac, string correo, int frecuente, Comuna comuna, Region region, Nacionalidad nacionalidad)
        {
            Id_cliente = id_cliente;
            Rut = rut;
            Nombre = nombre;
            Primer_ape = primer_ape;
            Segundo_ape = segundo_ape;
            Direccion = direccion;
            Telefono = telefono;
            Fecha_nac = fecha_nac;
            Correo = correo;
            Frecuente = frecuente;
            Comuna = comuna;
            Region = region;
            Nacionalidad = nacionalidad;
        }

        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public string Rut { get => _rut; set => _rut = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Primer_ape { get => _primer_ape; set => _primer_ape = value; }
        public string Segundo_ape { get => _segundo_ape; set => _segundo_ape = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public DateTime Fecha_nac { get => _fecha_nac; set => _fecha_nac = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public int Frecuente { get => _frecuente; set => _frecuente = value; }
        public Comuna Comuna { get => _comuna; set => _comuna = value; }
        public Region Region { get => _region; set => _region = value; }
        public Nacionalidad Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
    }
}
