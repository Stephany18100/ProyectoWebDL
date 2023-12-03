using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWebDL.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int PKUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }


        [ForeignKey("Roles")]
        public int? FkRol { get; set; }
        public Rol Roles { get; set; }
    }
}
