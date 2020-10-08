using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EstadoDepartamento
    {
        private int _id_departamento;
        private string _descripcion;

        public EstadoDepartamento(int id_departamento, string descripcion)
        {
            this._id_departamento = id_departamento;
            this._descripcion = descripcion;
        }

        public int Id_departamento { get => _id_departamento; set => _id_departamento = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
