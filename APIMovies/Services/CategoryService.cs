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

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto categoryCreateUpdateDto, int id)
        {

            var categoryExisting = await GetCategoryByIdAsync(id);

            var categoryName =  await _categoryRepository.CategoryExistsByNameAsync(categoryCreateUpdateDto.Name);

            if (categoryName)
            {
                throw new InvalidOperationException($"Category with name '{categoryCreateUpdateDto.Name}' already exists.");
            }

            _mapper.Map(categoryCreateUpdateDto, categoryExisting);

            var isUpdated = await _categoryRepository.UpdateCategoryAsync(categoryExisting);

            if (!isUpdated)
            {
                throw new Exception("Failed to update category.");
            }

            return _mapper.Map<CategoryDto>(categoryExisting);
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            await GetCategoryByIdAsync(id);

            var isDeleted = await _categoryRepository.DeleteCategoryAsync(id);

            if (!isDeleted) 
            {
                throw new Exception("Failed to delete category.");
            }
            
            return isDeleted;
        }

        private async Task<Category> GetCategoryByIdAsync(int id) 
        {

            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id '{id}' not found.");
            }

            return category;
        }

        public Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

    }
}
