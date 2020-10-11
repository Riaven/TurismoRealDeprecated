using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EstadoDepartamento
    {
        private int _id_estado_departamento;
        private string _descripcion;

        public EstadoDepartamento()
        {
        }

        public EstadoDepartamento(int id_estado_departamento, string descripcion)
        {
            Id_estado_departamento = id_estado_departamento;
            Descripcion = descripcion;
        }

        public int Id_estado_departamento { get => _id_estado_departamento; set => _id_estado_departamento = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
