using System.ComponentModel.DataAnnotations;

namespace ProyectoWebDL.Models.Entities
{
    public class Libro
    {
        [Key]
        public int PkLibro { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Images { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
