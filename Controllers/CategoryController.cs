
using Microsoft.AspNetCore.Mvc;
using Shop.Dto.Category;
using Shop.Models;

[Route("categories")]
public class CategoryController : Controller
{
    private readonly ICategoryInterface _categoryInterface;

    public CategoryController(ICategoryInterface categoryInterface)
    {
        _categoryInterface = categoryInterface;
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<List<Category>>> GetCategories()
    {
        var categories = await _categoryInterface.GetCategories();

        if (categories == null || !categories.Any())
            return NotFound("Nenhuma categoria encontrada.");

        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        var category = await _categoryInterface.GetCategoryById(id);

        if (category == null || category.Id == 0)
            return NotFound("Nenhuma categoria encontrada.");

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory([FromBody] CategoryCreateDto categoryDto)
    {

        var createdCategory = await _categoryInterface.CreateCategory(categoryDto);

        if (createdCategory == null)
        {
            return StatusCode(500, new { message = "Erro ao criar a categoria." });
        }

        return createdCategory;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Category>> UpdateCategory(int id, [FromBody]CategoryUpdateDto categoryDto)
    {
        var updatedCategory = await _categoryInterface.UpdateCategory(id, categoryDto);
        if (updatedCategory == null)
        {
            return NotFound("Categoria não encontrada ou erro ao atualizar.");
        }
        return Ok(updatedCategory);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteCategory(int id)
    {
        var deleteCategory = await _categoryInterface.DeleteCategory(id);

        if(!deleteCategory)
        {
            return NotFound("Categoria não encontrada ou erro na exclusão.");
        }

        return NoContent();
    }
}