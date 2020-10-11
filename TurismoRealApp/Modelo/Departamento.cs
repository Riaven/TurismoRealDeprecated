using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Departamento
    {
        private int _id_departamento;
        private string _direccion;
        private int _numero;
        private int _precio;
        private string _m_cuadrados;
        private int _banios;
        private string _descripcion;
        private int _cantidad_habitacion;
        private EstadoDepartamento _estado_departamento;
        private Region _region;
        private Comuna _comuna;
        private Inventario _inventario;
        private Empleado _funcionario;
        private ServicioExtra _servicio_extra;

        public Departamento()
        {
        }

        public Departamento(int id_departamento, string direccion, int numero, int precio, string cuadrados, int banios, string descripcion, int cantidad_habitacion, EstadoDepartamento estado_departamento, Region region, Comuna comuna, Inventario inventario, Empleado funcionario, ServicioExtra servicio_extra)
        {
            Id_departamento = id_departamento;
            Direccion = direccion;
            Numero = numero;
            Precio = precio;
            Cuadrados = cuadrados;
            Banios = banios;
            Descripcion = descripcion;
            Cantidad_habitacion = cantidad_habitacion;
            Estado_departamento = estado_departamento;
            Region = region;
            Comuna = comuna;
            Inventario = inventario;
            Funcionario = funcionario;
            Servicio_extra = servicio_extra;
        }

        public int Id_departamento { get => _id_departamento; set => _id_departamento = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public int Numero { get => _numero; set => _numero = value; }
        public int Precio { get => _precio; set => _precio = value; }
        public string Cuadrados { get => _m_cuadrados; set => _m_cuadrados = value; }
        public int Banios { get => _banios; set => _banios = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int Cantidad_habitacion { get => _cantidad_habitacion; set => _cantidad_habitacion = value; }
        public EstadoDepartamento Estado_departamento { get => _estado_departamento; set => _estado_departamento = value; }
        public Region Region { get => _region; set => _region = value; }
        public Comuna Comuna { get => _comuna; set => _comuna = value; }
        public Inventario Inventario { get => _inventario; set => _inventario = value; }
        public Empleado Funcionario { get => _funcionario; set => _funcionario = value; }
        public ServicioExtra Servicio_extra { get => _servicio_extra; set => _servicio_extra = value; }
    }
}
