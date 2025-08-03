namespace Shop.Services.Products;

using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Dto.Category;
using Shop.Dto.ProductDto;
using Shop.Models;

public class ProductService : IProductInterface
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<ProductResponseDto> CreateProduct(ProductCreateDto productDto)
    {
        try
        {

            var category = _context.Categories
                .FirstOrDefault(category => category.Id == productDto.CategoryId);

            if(category == null)
            {
                throw new ArgumentException("Categoria não encontrada.");
            }

            var product = new Product
            {
                Title = productDto.Title,
                Description = productDto.Description,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var produtResponse = new ProductResponseDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Category = new CategoryResponseDto
                {
                    Name = category.Name
                }
            };

            return produtResponse;
        }
        catch(Exception ex)
        {
            throw new InvalidOperationException("An error occurred while creating the product.", ex);
        }
    }

    public Task<bool> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductResponseDto>> GetAllProducts()
    {
        try
        {
            var products = await _context.Products
                .Include(product => product.Category)
                .ToListAsync();

            if (products == null || products.Count == 0)
            {
                throw new ArgumentException("Nenhum produto cadastrado");
            }

            var productDtos = products.Select(static product => new ProductResponseDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Category = new CategoryResponseDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            }).ToList();

            return productDtos;
        } catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while retrieving products.", ex);
        }
    }

    public Task<ProductResponseDto> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponseDto> UpdateProduct(int id, ProductUpdateDto productDto)
    {
        throw new NotImplementedException();
    }
}
