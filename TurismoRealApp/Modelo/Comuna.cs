using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Comuna
    {
        private int _id_comuna;
        private string _nombre;
        private Region _region;

        public Comuna()
        {

        }

        public Comuna(int id_comuna, string nombre, Region region)
        {
            Id_comuna = id_comuna;
            Nombre = nombre;
            Region = region;
        }

        public int Id_comuna { get => _id_comuna; set => _id_comuna = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public Region Region { get => _region; set => _region = value; }
    }
}
