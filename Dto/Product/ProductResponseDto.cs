using Shop.Dto.Category;
using System.ComponentModel.DataAnnotations;

namespace Shop.Dto.ProductDto
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public CategoryResponseDto Category { get; set; }
    }
}
