using APIMovies.DAL.Dtos.Category;
using APIMovies.DAL.Dtos.Movie;
using APIMovies.DAL.Models;
using APIMovies.Repository;
using APIMovies.Repository.IRepository;
using APIMovies.Services.IServices;
using AutoMapper;

namespace APIMovies.Services
{
    public class MovieService : IMovieService
    {
        readonly IMovieRepository _movieRepository;
        readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateUpdateDto)
        {
            var movieExist = await _movieRepository.MovieExistsByNameAsync(movieCreateUpdateDto.Name);

            if (movieExist)
            {
                throw new InvalidOperationException($"Movie with name '{movieCreateUpdateDto.Name}' already exists");
            }

            var movie = _mapper.Map<Movie>(movieCreateUpdateDto);
            var createdMovie = await _movieRepository.CreateMovieAsync(movie);

            if (!createdMovie)
            {
                throw new Exception("Failed to create movie.");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto movieCreateUpdateDto, int id)
        {
            var movieExisting = await GetMovieByIdAsync(id);

            var categoryName = await _movieRepository.MovieExistsByNameAsync(movieCreateUpdateDto.Name);

            if (categoryName)
            {
                throw new InvalidOperationException($"Movie with name '{movieCreateUpdateDto.Name}' already exists.");
            }

            _mapper.Map(movieCreateUpdateDto, movieExisting);

            var isUpdated = await _movieRepository.UpdateMovieAsync(movieExisting);

            if (!isUpdated)
            {
                throw new Exception("Failed to update movie.");
            }

            return _mapper.Map<MovieDto>(movieExisting);
        }

        private async Task<Movie> GetMovieByIdAsync(int id)
        {

            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with id '{id}' not found.");
            }

            return movie;
        }
        public async Task<bool> DeleteMovieAsync(int id)
        {
            await GetMovieByIdAsync(id);

            var isDeleted = await _movieRepository.DeleteMovieAsync(id);

            if (!isDeleted)
            {
                throw new Exception("Failed to delete category.");
            }

            return isDeleted;
        }

        public Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
