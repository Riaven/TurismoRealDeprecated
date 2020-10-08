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

        public Comuna(int id_comuna, string nombre)
        {
            this._id_comuna = id_comuna;
            this._nombre = nombre;
        }

        public int Id_comuna { get => _id_comuna; set => _id_comuna = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}
