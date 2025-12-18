using GestionEstudiantes.Models;

namespace GestionEstudiantes.Repositories
{
    public interface IEstudianteRepository
    {
        IEnumerable<Estudiante> GetAllEstudiantes();
        Estudiante GetEstudianteById(int id);
    }
}
