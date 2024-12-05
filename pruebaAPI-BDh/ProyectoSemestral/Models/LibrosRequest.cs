﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemestral.Models
{
    public class LibrosRequest
    {
        public string titulo { get; set; } = string.Empty;

        public string autor { get; set; } = string.Empty;

        public decimal precio { get; set; }

        public string urlPortada { get; set; }

        public int idgenero { get; set; }
        public string Descripcion { get; set; }
    }
}