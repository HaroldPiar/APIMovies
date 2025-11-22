using APIMovies.DAL.Dtos.Category;
using APIMovies.DAL.Dtos.Movie;
using APIMovies.DAL.Models;
using AutoMapper;

namespace APIMovies.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();
            CreateMap <Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateUpdateDto>().ReverseMap();

        }
    }
}
