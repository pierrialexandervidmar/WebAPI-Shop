using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Dto.ProductDto;

namespace Shop.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductInterface _productInterface;

        public ProductController(IProductInterface productInterface)
        {
            _productInterface = productInterface;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<List<ProductResponseDto>>> GetAllProducts()
        {
            var products = await _productInterface.GetAllProducts();

            if (products == null || !products.Any())
                return NotFound("Nenhum produto encontrado.");

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<ProductResponseDto>> GetProductById(int id)
        {
            var product = await _productInterface.GetProductById(id);

            if (product == null)
                return NotFound(new { message = "Produto não encontrado." });
            
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> CreateProduct([FromBody] ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var createdProduct = await _productInterface.CreateProduct(productDto);

            if (createdProduct == null)
            {
                return UnprocessableEntity(new { message = "Erro ao criar o produto." });
            }

            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<ProductResponseDto>> UpdateProduct(int id, [FromBody] ProductUpdateDto productDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var updatedProduct = await _productInterface.UpdateProduct(id, productDto);
        //    if (updatedProduct == null)
        //    {
        //        return StatusCode(500, new { message = "Erro ao atualizar o produto." });
        //    }
        //    return Ok(updatedProduct);
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<bool>> DeleteProduct(int id)
        //{
        //    var isDeleted = await _productInterface.DeleteProduct(id);
        //    if (!isDeleted)
        //        return NotFound("Produto não encontrado ou erro ao deletar.");
        //    return NoContent();
        //}
    }
}
