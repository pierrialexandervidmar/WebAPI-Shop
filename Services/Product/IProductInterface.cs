using Shop.Dto.Product;
using Shop.Models;

public interface IProductInterface
{
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    Task<Product> CreateProduct(ProductCreateDto productDto);
    Task<Product> UpdateProduct(int id, ProductUpdateDto productDto);
    Task<bool> DeleteProduct(int id);
}

