using AutoMapper;
using GestionEstudiantes.DTO;
using GestionEstudiantes.Models;
using GestionEstudiantes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GestionEstudiantes.Controllers
{
    [Route("api/[controller]")] // http://localhost:5000/api/estudiante
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository repo;
        private readonly IMapper mapper;
        public EstudianteController(IEstudianteRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EstudianteReadDTO>> GetEstudiantes()
        {
            var estudiantes = repo.GetAllEstudiantes();
            return Ok(mapper.Map<IEnumerable<EstudianteReadDTO>>(estudiantes));
        }
        [HttpGet("{id}", Name = "GetEstudianteById")]
        public ActionResult<EstudianteReadDTO> GetEstudianteById(int id)
        {
            var estudiante = repo.GetEstudianteById(id);
            if (estudiante == null)
                return NotFound();
            return Ok(mapper.Map<EstudianteReadDTO>(estudiante));
        }
        [HttpPost]
        public ActionResult<EstudianteReadDTO> CreateEstudiante(EstudianteCreateDTO estudianteCreateDTO)
        {
            var estudianteModel = mapper.Map<Estudiante>(estudianteCreateDTO);
            repo.AddEstudiante(estudianteModel);
            repo.Guardar();
            var estudianteReadDTO = mapper.Map<EstudianteReadDTO>(estudianteModel);
            return CreatedAtRoute(nameof(GetEstudianteById), new { id = estudianteModel.Id }, estudianteReadDTO);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateEstudiante(int id, EstudianteUpdateDTO estudianteUpdateDTO)
        {
            var estudianteModelFromRepo = repo.GetEstudianteById(id);
            if (estudianteModelFromRepo == null)
                return NotFound();
            mapper.Map(estudianteUpdateDTO, estudianteModelFromRepo);
            repo.UpdateEstudiante(estudianteModelFromRepo);
            repo.Guardar();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult PartialEstudianteUpdate(int id, JsonPatchDocument<EstudianteUpdateDTO> patchDoc)
        {
            var estudianteModelFromRepo = repo.GetEstudianteById(id);
            if (estudianteModelFromRepo == null)
                return NotFound();
            var estudianteToPatch = mapper.Map<EstudianteUpdateDTO>(estudianteModelFromRepo);
            patchDoc.ApplyTo(estudianteToPatch, ModelState);
            if (!TryValidateModel(estudianteToPatch))
            {
                return ValidationProblem(ModelState);
            }
            mapper.Map(estudianteToPatch, estudianteModelFromRepo);
            repo.UpdateEstudiante(estudianteModelFromRepo);
            repo.Guardar();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteEstudiante(int id)
        {
            var estudianteModelFromRepo = repo.GetEstudianteById(id);
            if (estudianteModelFromRepo == null)
                return NotFound();
            repo.DeleteEstudianteById(estudianteModelFromRepo);
            repo.Guardar();
            return NoContent();
        }
    }
}
