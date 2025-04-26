namespace EquiposPeruanos.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Posicion { get; set; } = string.Empty;
    }
}