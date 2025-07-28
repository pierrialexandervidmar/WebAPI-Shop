
using Shop.Dto.Category;
using Shop.Models;

public interface ICategoryInterface
{
    Task<List<Category>> GetCategories();
    Task<Category> GetCategoryById(int id);
    Task<Category> CreateCategory(CategoryCreateDto categoryCreationDto);
    Task<Category> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto);
    Task<bool> DeleteCategory(int id);
}
