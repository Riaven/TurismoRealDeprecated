using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class TipoGasto
    {
        private int _id_gasto;
        private string _descripcion;

        public TipoGasto()
        {
        }

        public TipoGasto(int id_gasto, string descripcion)
        {
            Id_gasto = id_gasto;
            Descripcion = descripcion;
        }

        public int Id_gasto { get => _id_gasto; set => _id_gasto = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
