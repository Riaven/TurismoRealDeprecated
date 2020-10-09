using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Departamento
    {
        private int id_departamento;
        private string direccion;
        private int numero;
        private int precio;
        private string m_cuadrados;
        private int banios;
        private string descripcion;
        private int cantidad_habitacion;
        private EstadoDepartamento estado_departamento;
        private Region region;
        private Comuna comuna;
        private int inventario;
        private string funcionario;
        private ServicioExtra servicio_extra;

        public Departamento(int id_departamento, string direccion, int numero, int precio, string cuadrados, int banios, string descripcion, int cantidad_habitacion, EstadoDepartamento estado_departamento, Region region, Comuna comuna, int inventario, string funcionario, ServicioExtra servicio_extra)
        {
            this.id_departamento = id_departamento;
            this.direccion = direccion;
            this.numero = numero;
            this.precio = precio;
            m_cuadrados = cuadrados;
            this.banios = banios;
            this.descripcion = descripcion;
            this.cantidad_habitacion = cantidad_habitacion;
            this.estado_departamento = estado_departamento;
            this.region = region;
            this.comuna = comuna;
            this.inventario = inventario;
            this.funcionario = funcionario;
            this.servicio_extra = servicio_extra;
        }

        public Departamento()
        {

        }

        public int Id_departamento { get => id_departamento; set => id_departamento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Numero { get => numero; set => numero = value; }
        public int Precio { get => precio; set => precio = value; }
        public string Cuadrados { get => m_cuadrados; set => m_cuadrados = value; }
        public int Banios { get => banios; set => banios = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad_habitacion { get => cantidad_habitacion; set => cantidad_habitacion = value; }
        public EstadoDepartamento Estado_departamento { get => estado_departamento; set => estado_departamento = value; }
        public Region Region { get => region; set => region = value; }
        public Comuna Comuna { get => comuna; set => comuna = value; }
        public int Inventario { get => inventario; set => inventario = value; }
        public string Funcionario { get => funcionario; set => funcionario = value; }
        public ServicioExtra Servicio_extra { get => servicio_extra; set => servicio_extra = value; }
    }
}
