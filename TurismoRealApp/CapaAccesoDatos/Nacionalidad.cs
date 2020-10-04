using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Nacionalidad
    {
        private int _id_nacionalidad;
        private string _descripcion;

        public Nacionalidad(int id_nacionalidad, string descripcion)
        {
            Id_nacionalidad = id_nacionalidad;
            Descripcion = descripcion;
        }

        public int Id_nacionalidad { get => _id_nacionalidad; set => _id_nacionalidad = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
