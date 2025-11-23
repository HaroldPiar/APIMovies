using APIMovies.DAL.Dtos.Category;
using APIMovies.DAL.Models;

namespace APIMovies.Services.IServices
{
    public interface ICategoryService
    {
        /*
        Vamos a implementar el GetServices completo para Category
        Por estandares de nomenclatura/buenas practicas, se trean literal todos lo métodos del repositoryz
         */

        Task<ICollection<CategoryDto>> GetCategoriesAsync(); 
        Task<CategoryDto> GetCategoryAsync(int id); 
        Task<bool> CategoryExistsByIdAsync(int id); 
        Task<bool> CategoryExistsByNameAsync(string name); 
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateUpdateDto); 
        Task<CategoryDto> UpdateCategoryAsync(Category category); 
        Task<bool> DeleteCategoryAsync(int id); 
    }
}
