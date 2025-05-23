using System.Threading.Tasks;
using AutoMapper;
using FastFood.Application.DTOs;
using FastFood.Application.Interfaces.Services;
using FastFood.Application.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
        {
            var validationResult = new CreateProductRequestValidator().Validate(request);
            if(!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var product = _mapper.Map<Product>(request);
            await _productService.AddProduct(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product is null)
                return GetProductNotFoundMessage();

            var response = _mapper.Map<ProductResponse>(product);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request)
        {
            var validationResult = new UpdateProductRequestValidator().Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var productToUpdate = _mapper.Map<Product>(request);
            productToUpdate.Id = id;

            try
            {
                Product? productExists  = await _productService.UpdateProduct(productToUpdate);

                if (productExists is null)
                    return GetProductNotFoundMessage();
                
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);

                if (product is null)
                    return GetProductNotFoundMessage();

                await _productService.RemoveProduct(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = $"Erro ao remover o produto: {ex.Message}" });
            }
        }

        private IActionResult GetProductNotFoundMessage()
        {
            return NotFound(new { message = "Produto não encontrado." });
        }
    }
}
