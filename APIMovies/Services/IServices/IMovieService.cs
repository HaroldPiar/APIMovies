using APIMovies.DAL.Dtos.Movie;
using APIMovies.DAL.Models;

namespace APIMovies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id); 
        Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateUpdateDto); 
        Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto movieCreateUpdateDto, int id); 
        Task<bool> DeleteMovieAsync(int id);
    }
}
