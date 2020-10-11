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
        private ZonaMueble _zona_inmueble;
        private Departamento _departamento;
        private EstadoInmueble _estado_inmueble;

        public Inventario()
        {

        }

        public Inventario(int id_inventario, string nombre_mueble, string descripcion, ZonaMueble zona_inmueble, Departamento departamento, EstadoInmueble estado_inmueble)
        {
            Id_inventario = id_inventario;
            Nombre_mueble = nombre_mueble;
            Descripcion = descripcion;
            Zona_inmueble = zona_inmueble;
            Departamento = departamento;
            Estado_inmueble = estado_inmueble;
        }

        public int Id_inventario { get => _id_inventario; set => _id_inventario = value; }
        public string Nombre_mueble { get => _nombre_mueble; set => _nombre_mueble = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public ZonaMueble Zona_inmueble { get => _zona_inmueble; set => _zona_inmueble = value; }
        public Departamento Departamento { get => _departamento; set => _departamento = value; }
        public EstadoInmueble Estado_inmueble { get => _estado_inmueble; set => _estado_inmueble = value; }
    }
}
