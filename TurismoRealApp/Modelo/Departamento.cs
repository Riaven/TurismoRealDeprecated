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
        private string _ubicacion;
        private int _numero;
        private int _precio;
        private int _m_cuadrados;
        private int _banios;
        private string _descripcion;
        private int _cantidad_habitacion;
        private EstadoDepartamento _estado_departamento;
        private Comuna _comuna;
        private Empleado _funcionario;

        public Departamento()
        {
        }

        public Departamento(int id_departamento, string ubicacion, int numero, int precio, int cuadrados, int banios, string descripcion, int cantidad_habitacion, EstadoDepartamento estado_departamento, Comuna comuna, Empleado funcionario)
        {
            Id_departamento = id_departamento;
            Ubicacion = ubicacion;
            Numero = numero;
            Precio = precio;
            Cuadrados = cuadrados;
            Banios = banios;
            Descripcion = descripcion;
            Cantidad_habitacion = cantidad_habitacion;
            Estado_departamento = estado_departamento;
            Comuna = comuna;
            Funcionario = funcionario;
        }

        public int Id_departamento { get => _id_departamento; set => _id_departamento = value; }
        public string Ubicacion { get => _ubicacion; set => _ubicacion = value; }
        public int Numero { get => _numero; set => _numero = value; }
        public int Precio { get => _precio; set => _precio = value; }
        public int Cuadrados { get => _m_cuadrados; set => _m_cuadrados = value; }
        public int Banios { get => _banios; set => _banios = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int Cantidad_habitacion { get => _cantidad_habitacion; set => _cantidad_habitacion = value; }
        public EstadoDepartamento Estado_departamento { get => _estado_departamento; set => _estado_departamento = value; }
        public Comuna Comuna { get => _comuna; set => _comuna = value; }
        public Empleado Funcionario { get => _funcionario; set => _funcionario = value; }
    }
}
