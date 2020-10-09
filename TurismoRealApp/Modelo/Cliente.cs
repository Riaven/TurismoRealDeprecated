using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {
        private int id_cliente;
        private string rut;
        private string nombre;
        private string primer_ape;
        private string segundo_ape;
        private string direccion;
        private string telefono;
        private DateTime fecha_nac;
        private string correo;
        private int frecuente;
        Comuna comuna;
        Region region;
        Nacionalidad nacionalidad;

        public Cliente()
        {

        }

        public Cliente(int id_cliente, string rut, string nombre, string primer_ape, string segundo_ape, string direccion, string telefono, DateTime fecha_nac, string correo, int frecuente, Comuna comuna, Region region, Nacionalidad nacionalidad)
        {
            this.id_cliente = id_cliente;
            this.rut = rut;
            this.nombre = nombre;
            this.primer_ape = primer_ape;
            this.segundo_ape = segundo_ape;
            this.direccion = direccion;
            this.telefono = telefono;
            this.fecha_nac = fecha_nac;
            this.correo = correo;
            this.frecuente = frecuente;
            this.comuna = comuna;
            this.region = region;
            this.nacionalidad = nacionalidad;
        }

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Primer_ape { get => primer_ape; set => primer_ape = value; }
        public string Segundo_ape { get => segundo_ape; set => segundo_ape = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime Fecha_nac { get => fecha_nac; set => fecha_nac = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Frecuente { get => frecuente; set => frecuente = value; }
        public Comuna Comuna { get => comuna; set => comuna = value; }
        public Region Region { get => region; set => region = value; }
        public Nacionalidad Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
    }
}
