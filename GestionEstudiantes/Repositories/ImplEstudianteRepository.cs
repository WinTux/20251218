using GestionEstudiantes.Models;

namespace GestionEstudiantes.Repositories
{
    public class ImplEstudianteRepository : IEstudianteRepository
    {
        public IEnumerable<Estudiante> GetAllEstudiantes()
        {
            IEnumerable<Estudiante> estudiantes = new List<Estudiante>
            {
                new Estudiante { Id = 1, Nombre = "Pepe", Apellido = "Perales", FechaNacimiento = new DateTime(2000, 5, 15), Email = "pepe@gmail.com" },
                new Estudiante { Id = 2, Nombre = "Ana", Apellido = "Sosa", FechaNacimiento = new DateTime(2000, 5, 10), Email = "ana@gmail.com" }
            }; 
            return estudiantes;
        }

        public Estudiante GetEstudianteById(int id)
        {
            return new Estudiante { Id = 1, Nombre = "Pepe", Apellido = "Perales", FechaNacimiento = new DateTime(2000, 5, 15), Email = "pepe@gmail.com" };
        }
    }
}
