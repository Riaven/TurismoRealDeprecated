using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class CargoEmpleado
    {
        private int _id_cargo;
        private string _descripcion;

        public CargoEmpleado(int id_cargo, string descripcion)
        {
            Id_cargo = id_cargo;
            Descripcion = descripcion;
        }

        public int Id_cargo { get => _id_cargo; set => _id_cargo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
