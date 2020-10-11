using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class FacturaBoleta
    {
        private int _id_boleta_factura;
        private int _num_factura_boleta;
        private string _foto; //contiene la url de la foto de la factura

        public FacturaBoleta()
        {

        }

        public FacturaBoleta(int id_boleta_factura, int num_factura_boleta, string foto)
        {
            Id_boleta_factura = id_boleta_factura;
            Num_factura_boleta = num_factura_boleta;
            Foto = foto;
        }

        public int Id_boleta_factura { get => _id_boleta_factura; set => _id_boleta_factura = value; }
        public int Num_factura_boleta { get => _num_factura_boleta; set => _num_factura_boleta = value; }
        public string Foto { get => _foto; set => _foto = value; }
    }
}
