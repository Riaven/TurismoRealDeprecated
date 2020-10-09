using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Region
    {
        private int _id_region;
        private string _nombre;

        public Region()
        {

        }
        public Region(int id_region, string nombre)
        {
            Id_region = id_region;
            Nombre = nombre;
        }

        public int Id_region { get => _id_region; set => _id_region = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}
