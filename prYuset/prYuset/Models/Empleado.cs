namespace prYuset.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }

        public int Nombre { get; set; }

        public int Cargo { get; set; }
        public Cargo Cargos { get; set; }
    }
}
