namespace ENT
{
    public class Personas
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        // Constructor sin parámetros
        public Personas()
        {
        }

        // Constructor con parámetros
        public Personas(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
        }
    }
}
