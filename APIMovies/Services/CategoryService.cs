using APIMovies.DAL.Dtos.Category;
using APIMovies.DAL.Models;
using APIMovies.Repository.IRepository;
using APIMovies.Services.IServices;
using AutoMapper;

namespace APIMovies.Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }



        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<ICollection<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if(category == null)
            {
                throw new InvalidOperationException($"Category with id {id} not found.");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateUpdateDto)
        {
            var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateUpdateDto.Name);

            if (categoryExists)
            {
                throw new InvalidOperationException($"Category with name '{categoryCreateUpdateDto.Name}' already exists.");
            }

            var category = _mapper.Map<Category>(categoryCreateUpdateDto);
            var createdCategory = await _categoryRepository.CreateCategoryAsync(category);

            if (!createdCategory) { 
                throw new Exception("Failed to create category.");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        /*-------------------------*/
        public Task<CategoryDto> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }



        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
