using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWebDL.Models.Entities
{
    public class Articulo
    {
        [Key]
        public int PkArticulo { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public double Precio { get; set; }

        [NotMapped]
        [Display(Name = "Imagen")]
        public IFormFile Img {  get; set; }
        public string UrlImagenPath {  get; set; }
    }
}
