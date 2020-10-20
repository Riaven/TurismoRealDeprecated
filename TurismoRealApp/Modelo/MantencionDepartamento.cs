using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MantencionDepartamento
    {
        private int _id_mantenimiento;
        private string _descripcion_mante;
        private int _costo;
        private Departamento _departamento;
        private DateTime _fecha;
        private TipoGasto _tipo_gasto;
        private FacturaBoleta _factura_boleta;

        public MantencionDepartamento()
        {

        }

        public MantencionDepartamento(int id_mantenimiento, string descripcion_mante, int costo, Departamento departamento, DateTime fecha, TipoGasto tipo_gasto, FacturaBoleta factura_boleta)
        {
            Id_mantenimiento = id_mantenimiento;
            Descripcion_mante = descripcion_mante;
            Costo = costo;
            Departamento = departamento;
            Fecha = fecha;
            Tipo_gasto = tipo_gasto;
            Factura_boleta = factura_boleta;
        }

        public int Id_mantenimiento { get => _id_mantenimiento; set => _id_mantenimiento = value; }
        public string Descripcion_mante { get => _descripcion_mante; set => _descripcion_mante = value; }
        public int Costo { get => _costo; set => _costo = value; }
        public Departamento Departamento { get => _departamento; set => _departamento = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public TipoGasto Tipo_gasto { get => _tipo_gasto; set => _tipo_gasto = value; }
        public FacturaBoleta Factura_boleta { get => _factura_boleta; set => _factura_boleta = value; }
    }
}
