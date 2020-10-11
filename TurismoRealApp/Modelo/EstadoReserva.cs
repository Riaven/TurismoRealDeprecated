using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EstadoReserva
    {
        private int _id_estado_reserva;
        private string _descripcion;

        public EstadoReserva()
        {

        }

        public EstadoReserva(int id_estado_reserva, string descripcion)
        {
            Id_estado_reserva = id_estado_reserva;
            Descripcion = descripcion;
        }

        public int Id_estado_reserva { get => _id_estado_reserva; set => _id_estado_reserva = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
