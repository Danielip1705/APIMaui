using System;
using System.Collections.Generic;
using System.Linq;
using ENT;

namespace DAL
{
    public class ManejadoraPersonas
    {
        // Lista estática de personas ya predefinidas (10 personas)
        private static List<Personas> personasList = new List<Personas>
        {
            new Personas(1, "Juan Pérez", "Calle Falsa 123"),
            new Personas(2, "Ana Gómez", "Avenida Siempre Viva 456"),
            new Personas(3, "Carlos López", "Calle Gran Vía 789"),
            new Personas(4, "María Fernández", "Calle del Sol 321"),
            new Personas(5, "Luis García", "Calle Luna 654"),
            new Personas(6, "Elena Martínez", "Avenida del Río 987"),
            new Personas(7, "Pedro Sánchez", "Calle del Parque 159"),
            new Personas(8, "Laura Rodríguez", "Avenida del Mar 753"),
            new Personas(9, "Jorge Díaz", "Calle de los Árboles 258"),
            new Personas(10, "Sofía González", "Avenida del Sol 654")
        };

        // Función para listar todas las personas
        public static List<Personas> ListarPersonas()
        {
            return personasList;
        }

        // Función para buscar una persona por su Id
        public static Personas BuscarPersonaPorId(int id)
        {
            return personasList.FirstOrDefault(p => p.Id == id);
        }

        // Función para actualizar una persona
        public static bool ActualizarPersona(int id, string nombre, string direccion)
        {
            Personas persona = BuscarPersonaPorId(id);
            if (persona != null)
            {
                persona.Nombre = nombre;
                persona.Direccion = direccion;
                return true;
            }
            return false;
        }

        // Función para crear una nueva persona
        public static void CrearPersona(int id, string nombre, string direccion)
        {
            Personas personaNueva = new Personas(id, nombre, direccion);
            personasList.Add(personaNueva);
        }

        // Función para eliminar una persona por su Id
        public static bool EliminarPersona(int id)
        {
            Personas persona = BuscarPersonaPorId(id);
            if (persona != null)
            {
                personasList.Remove(persona);
                return true;
            }
            return false;
        }
    }
}
