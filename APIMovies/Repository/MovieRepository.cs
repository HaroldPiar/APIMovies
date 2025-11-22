using APIMovies.DAL;
using APIMovies.DAL.Models;
using APIMovies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIMovies.Repository
{
    public class MovieRepository : IMovieRepository
    {

        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context  = context;
        }
        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() <= 0 ? true : false; ;
        }
        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _context.Movies.
                AsNoTracking().
                FirstOrDefaultAsync(c => c.Id == id);
        }
        
        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.
                AsNoTracking().
                OrderBy(c => c.Name).
                ToListAsync();
        }        
        
        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;
            await _context.Movies.AddAsync(movie);
            return await SaveAsync();
        }
        
        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.
                FirstOrDefaultAsync(c => c.Id == id);

            if (movie == null)
                return false;

            _context.Movies.Remove(movie);
            return await SaveAsync();
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.ModifiedDate = DateTime.UtcNow;
            _context.Movies.Update(movie);
            return await SaveAsync();
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _context.
                Movies.
                AsNoTracking().
                AnyAsync(c => c.Id == id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _context.
                Movies.
                AsNoTracking().
                AnyAsync(c => c.Name == name);
        }
    }
}
