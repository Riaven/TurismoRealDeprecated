﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ZonaMueble
    {
        private int _id_zona;
        private string _descripcion;

        public ZonaMueble()
        {

        }

        public ZonaMueble(int id_zona, string descripcion)
        {
            this.Id_zona = id_zona;
            this.Descripcion = descripcion;
        }

        public int Id_zona { get => _id_zona; set => _id_zona = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
