using System.ComponentModel.DataAnnotations;

namespace Shop.Dto.ProductDto
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(200, ErrorMessage = "O nome não pode exceder 200 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "A descrição não pode exceder 1024 caracteres.")]
        public string Description { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione uma categoria válida.")]
        public int CategoryId { get; set; }
    }
}
