using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EstadoInmueble
    {
        private int _id_estado_inmueble;
        private string _nombre_estado;

        public EstadoInmueble()
        {

        }

        public EstadoInmueble(int id_estado_inmueble, string nombre_estado)
        {
            Id_estado_inmueble = id_estado_inmueble;
            Nombre_estado = nombre_estado;
        }

        public int Id_estado_inmueble { get => _id_estado_inmueble; set => _id_estado_inmueble = value; }
        public string Nombre_estado { get => _nombre_estado; set => _nombre_estado = value; }
    }
}
