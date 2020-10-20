using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pago
    {
        private int _id_pago;
        private DateTime _fecha_pago;
        private string _detalle;
        private int _total_pago;

        public Pago()
        {

        }

        public Pago(int id_pago, DateTime fecha_pago, string detalle, int total_pago)
        {
            Id_pago = id_pago;
            Fecha_pago = fecha_pago;
            Detalle = detalle;
            Total_pago = total_pago;
        }

        public int Id_pago { get => _id_pago; set => _id_pago = value; }
        public DateTime Fecha_pago { get => _fecha_pago; set => _fecha_pago = value; }
        public string Detalle { get => _detalle; set => _detalle = value; }
        public int Total_pago { get => _total_pago; set => _total_pago = value; }
    }
}
