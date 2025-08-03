using Shop.Dto.ProductDto;
using Shop.Models;

public interface IProductInterface
{
    Task<List<ProductResponseDto>> GetAllProducts();
    Task<ProductResponseDto> GetProductById(int id);
    Task<ProductResponseDto> CreateProduct(ProductCreateDto productDto);
    Task<ProductResponseDto> UpdateProduct(int id, ProductUpdateDto productDto);
    Task<bool> DeleteProduct(int id);
}

