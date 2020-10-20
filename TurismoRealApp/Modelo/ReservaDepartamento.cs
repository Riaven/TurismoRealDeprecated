using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ReservaDepartamento
    {
        private int _id_reserva;
        private DateTime _fecha_inicio; 
        private DateTime _fecha_termino;
        private int _total_reserva;
        private int _pago_reserva;//quitar
        private Cliente _cliente;
        private EstadoReserva _estado_reserva;
        private Pago _pago; //esto deberia ser otra tabla adicional en la base de datos

        public ReservaDepartamento()
        {

        }

        public ReservaDepartamento(int id_reserva, DateTime fecha_inicio, DateTime fecha_termino, int total_reserva, int pago_reserva, Cliente cliente, EstadoReserva estado_reserva, Pago pago)
        {
            Id_reserva = id_reserva;
            Fecha_inicio = fecha_inicio;
            Fecha_termino = fecha_termino;
            Total_reserva = total_reserva;
            Pago_reserva = pago_reserva;
            Cliente = cliente;
            Estado_reserva = estado_reserva;
            Pago = pago;
        }

        public int Id_reserva { get => _id_reserva; set => _id_reserva = value; }
        public DateTime Fecha_inicio { get => _fecha_inicio; set => _fecha_inicio = value; }
        public DateTime Fecha_termino { get => _fecha_termino; set => _fecha_termino = value; }
        public int Total_reserva { get => _total_reserva; set => _total_reserva = value; }
        public int Pago_reserva { get => _pago_reserva; set => _pago_reserva = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public EstadoReserva Estado_reserva { get => _estado_reserva; set => _estado_reserva = value; }
        public Pago Pago { get => _pago; set => _pago = value; }
    }
}
