using GestionEstudiantes.Models;
using GestionEstudiantes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEstudiantes.Controllers
{
    [Route("api/[controller]")] // http://localhost:5000/api/estudiante
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository repo;
        public EstudianteController(IEstudianteRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Estudiante>> GetEstudiantes()
        {
            var estudiantes = repo.GetAllEstudiantes();
            return Ok(estudiantes);
        }
        [HttpGet("{id}")]
        public ActionResult<Estudiante> GetEstudianteById(int id)
        {
            var estudiante = repo.GetEstudianteById(id);
            if (estudiante == null)
                return NotFound();
            return Ok(estudiante);
        }
    }
}
