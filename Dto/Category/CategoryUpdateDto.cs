using System.ComponentModel.DataAnnotations;

namespace Shop.Dto.Category
{
    public class CategoryUpdateDto
    {
        [MaxLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        public string? Name { get; set; }
    }
}