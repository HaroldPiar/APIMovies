using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Dtos.Movie
{
    public class MovieDto
    {
        [Required(ErrorMessage = "El nombre de la película es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre de la película no puede exceder los 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La diración, en minutos, es obligatoria")]
        [MinLength(60, ErrorMessage = "Las películas inferiores a 1 hora son consideradas cortometrajes")] //Profe esto no es cierto, me lo inventé 
        public int Duration { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "La clasificación de la película es obligatoria")]
        public string Clasification { get; set; }
    }
}
