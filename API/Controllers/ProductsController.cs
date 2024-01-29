
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;



        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getAllProducts()
        {
            var listProducts = await _repository.getALlProductAsync();
            return Ok(listProducts);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            return await _repository.getProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getAllProductBrands()
        {
            var listProductBrands = await _repository.getAllProductBrandsAsync();
            return Ok(listProductBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> getAllProductsTypes()
        {
            var listProductTypes = await _repository.getAllProductTypesAsync();
            return Ok(listProductTypes);
        }
    }
}