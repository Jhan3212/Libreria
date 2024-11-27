namespace pruebaAPI_BD.Models
{
    public class Cliente
    {
        public int idCliente {  get; set; }
        public string nombre { get; set; } = string.Empty;
        public string direccion { get; set;} = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
