using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ServicioDepartamento
    {
        Departamento _departamento;
        ServicioExtra _servicio_extra;

        public ServicioDepartamento()
        {
        }

        public ServicioDepartamento(Departamento departamento, ServicioExtra servicio_extra)
        {
            Departamento = departamento;
            Servicio_extra = servicio_extra;
        }

        public Departamento Departamento { get => _departamento; set => _departamento = value; }
        public ServicioExtra Servicio_extra { get => _servicio_extra; set => _servicio_extra = value; }
    }
}
