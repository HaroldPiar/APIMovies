using APIMovies.DAL.Models;

namespace APIMovies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        /*usualmente, se crean todos los metodos CRUD
        Create - Read - Update - Delete, 
        usualmente salen 2 o 3 mas, dependiendo de las necesidades, para este ejemplo tendremos 7:

        Read: 
            - Lista de todas las categorias
            - Categoria por Id
            - Validacion de existencia de una categoria por Id
            - Validacion de existencia de una categoria por Nombre
        Create:
            - Crear una nueva categoria
        Update:
            - Actualizar una categoria existente
        Delete:
            - Eliminar una categoria existente
        */

        Task<ICollection<Category>> GetCategoriesAsync(); // Lista de todas las categorias
        Task<Category> GetCategoryAsync(int id); // Categoria por Id
        Task<bool> CategoryExistsByIdAsync(int id); // Validacion de existencia de una categoria por Id
        Task<bool> CategoryExistsByNameAsync(string name); // Validacion de existencia de una categoria por Nombre
        Task<bool> CreateCategoryAsync(Category category); // Crear una nueva categoria
        Task<bool> UpdateCategoryAsync(Category category); // Actualizar una categoria existente
        Task<bool> DeleteCategoryAsync(int id); // Eliminar una categoria existente
    }
}
