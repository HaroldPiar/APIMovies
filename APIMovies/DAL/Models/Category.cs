using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] //  Data anotation indica que el campo es obligatorio 
        [Display(Name = "Nombre de Categoria")]
        public string Name { get; set; } = string.Empty;
    }
}
