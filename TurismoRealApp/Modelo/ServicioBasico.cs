using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ServicioBasico
    {
        private int _id_servicio_basico;
        private string _descripcion_servicio;
        private int _total_pago_servicio;
        private FacturaBoleta _factura_boleta;

        public ServicioBasico()
        {

        }

        public ServicioBasico(int id_servicio_basico, string descripcion_servicio, int total_pago_servicio, FacturaBoleta factura_boleta)
        {
            Id_servicio_basico = id_servicio_basico;
            Descripcion_servicio = descripcion_servicio;
            Total_pago_servicio = total_pago_servicio;
            Factura_boleta = factura_boleta;
        }

        public int Id_servicio_basico { get => _id_servicio_basico; set => _id_servicio_basico = value; }
        public string Descripcion_servicio { get => _descripcion_servicio; set => _descripcion_servicio = value; }
        public int Total_pago_servicio { get => _total_pago_servicio; set => _total_pago_servicio = value; }
        public FacturaBoleta Factura_boleta { get => _factura_boleta; set => _factura_boleta = value; }
    }
}
