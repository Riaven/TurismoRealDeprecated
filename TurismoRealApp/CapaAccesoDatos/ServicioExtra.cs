﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaAccesoDatos
{
    public class ServicioExtra
    {
        private int _id_servicio_extra;
        private string _descripcion;

        public int Id_servicio_extra { get => _id_servicio_extra; set => _id_servicio_extra = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public int prueba()
        {
            return 1;
        }
        public ServicioExtra()
        {
        }
    }
}
