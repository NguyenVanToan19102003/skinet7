
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;
using API.Helpers;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {

        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
                                  IGenericRepository<ProductBrand> productBrandRepo,
                                  IGenericRepository<ProductType> productTypesRepo,
                                  IMapper mapper )
        {

            _mapper = mapper;
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypesRepo = productTypesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> getAllProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductWithFiletersForCountSpecification(productParams);

            var totalItems = await _productsRepo.CountAsync(countSpec);

            var listProducts = await _productsRepo.ListAsync(spec);
            
            var data = _mapper.Map<IReadOnlyList<Product> , IReadOnlyList<ProductToReturnDto>>(listProducts);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex , productParams.PageSize , totalItems , data));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> getProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productsRepo.GetEntityWithSpec(spec);
            if(product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product , ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getAllProductBrands()
        {
            var listProductBrands = await _productBrandRepo.ListAllAsync();
            return Ok(listProductBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> getAllProductsTypes()
        {
            var listProductTypes = await _productTypesRepo.ListAllAsync();
            return Ok(listProductTypes);
        }
    }
}