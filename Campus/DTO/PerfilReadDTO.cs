using System.ComponentModel.DataAnnotations;

namespace Campus.DTO
{
    public class PerfilReadDTO
    {
        public int Id { get; set; }
        [Required]
        public string NombrePerfil { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string lenguajes { get; set; }
        public int estudianteId { get; set; }
    }
}
