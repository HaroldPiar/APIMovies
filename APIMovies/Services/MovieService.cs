using APIMovies.DAL.Dtos.Category;
using APIMovies.DAL.Dtos.Movie;
using APIMovies.DAL.Models;
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
            var movies =  await _movieRepository.GetMoviesAsync();
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

            if (movieExist) {
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

        //----------------------------------------------------------------
        public async Task<bool> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto movieCreateUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
