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

        public async Task<Category> GetCategoryById(int id)
        {
            Category category = new Category();

            try
            {
                category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    return null;
                }

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar a categoria. Tente novamente mais tarde. Erro: " + ex.Message);
            }
        }

        public async Task<Category> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    return null;
                }

                category.Name = categoryUpdateDto.Name;
                _context.Categories.Update(category);

                await _context.SaveChangesAsync();

                // return category;
                return category;

            } catch (Exception ex)
            {
                throw new Exception("Houve um erro ao atualizar a categoria. Tente novamente mais tarde. Erro: " + ex.Message);
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    return false;
                }

                _context.Categories.Remove(category);

                await _context.SaveChangesAsync();

                // return category;
                return true;

            } catch (Exception ex)
            {
                throw new Exception("Houve um erro ao excluir a categoria. Tente novamente mais tarde. Erro: " + ex.Message);
            }
        }
    }
}