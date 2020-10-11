using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ZonaMueble
    {
        private int _id_zona_inmueble;
        private string _descripcion;

        public ZonaMueble()
        {

        }

        public ZonaMueble(int id_zona_inmueble, string descripcion)
        {
            this.Id_zona_inmueble = id_zona_inmueble;
            this.Descripcion = descripcion;
        }

        public int Id_zona_inmueble { get => _id_zona_inmueble; set => _id_zona_inmueble = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
