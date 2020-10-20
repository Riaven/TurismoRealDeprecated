using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Inventario
    {
        private int _id_inventario;
        private string _nombre_mueble;
        private string _descripcion;
        private EstadoMueble _estado_mueble;
        private ZonaMueble _zona_mueble;
        private Departamento _departamento;

        public Inventario()
        {

        }

        public Inventario(int id_inventario, string nombre_mueble, string descripcion, ZonaMueble zona_mueble, Departamento departamento, EstadoMueble estado_mueble)
        {
            Id_inventario = id_inventario;
            Nombre_mueble = nombre_mueble;
            Descripcion = descripcion;
            Zona_mueble = zona_mueble;
            Departamento = departamento;
            Estado_mueble = estado_mueble;
        }

        public int Id_inventario { get => _id_inventario; set => _id_inventario = value; }
        public string Nombre_mueble { get => _nombre_mueble; set => _nombre_mueble = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public ZonaMueble Zona_mueble { get => _zona_mueble; set => _zona_mueble = value; }
        public Departamento Departamento { get => _departamento; set => _departamento = value; }
        public EstadoMueble Estado_mueble { get => _estado_mueble; set => _estado_mueble = value; }
    }
}
