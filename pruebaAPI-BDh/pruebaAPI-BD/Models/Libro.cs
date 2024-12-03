namespace pruebaAPI_BD.Models
{
    public class Libro
    {
        public int idlibro { get; set; }

        public string titulo { get; set; } = string.Empty;

        public string autor { get; set; } = string.Empty;

        public decimal precio { get; set; }

        public string urlPortada { get; set; }

        public int idgenero { get; set;}
        public string Descripcion { get; set; }


    }
}
