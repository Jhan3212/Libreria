﻿namespace pruebaAPI_BD.Models
{
    public class LibroRequest
    {

        public string titulo { get; set; } = string.Empty;

        public string autor { get; set; } = string.Empty;

        public decimal precio { get; set; }

        public int stock { get; set; }
        public int idgenero { get; set; }

    }
}
