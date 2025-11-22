using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Dtos.Category
{
    public class CategoryCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre de la categoría no puede exceder los 100 caracteres")]
        public string Name { get; set; }
    }
}
