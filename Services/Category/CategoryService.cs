namespace Shop.Services.Category
{
    using Shop.Data;
    using Shop.Dto.Category;
    using Shop.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryInterface
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();

            try
            {
                categories = await _context.Categories.ToListAsync();

                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar as categorias. Tente novamente mais tarde. Erro: " + ex.Message);
            }
        }

        public async Task<Category> CreateCategory(CategoryCreateDto categoryCreationDto)
        {

            try
            {
                var category = new Category();

                category.Name = categoryCreationDto.Name;
                _context.Categories.Add(category);

                await _context.SaveChangesAsync();

                // return category;
                return category;

            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao criar a categoria. Tente novamente mais tarde. Erro: " + ex.Message);
            }



        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}