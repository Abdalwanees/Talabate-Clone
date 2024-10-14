using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabate.Clone.API.DTOs;
using Talabate.Clone.API.Errors;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Repository.Contruct;
using Talabate.Clone.Core.Specifications;
using Talabate.Clone.Core.Specifications.ProductSpecifications;

namespace Talabate.Clone.API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IGenaricRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IGenaricRepository<ProductBrand> _brands;
        private readonly IGenaricRepository<ProductCategories> _categories;

        public ProductsController(IGenaricRepository<Product> productRepository, IMapper mapper, IGenaricRepository<ProductBrand> brands, IGenaricRepository<ProductCategories> categories)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _brands = brands;
            _categories = categories;
        }

        // BaseUrl/api/Products
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var products = await _productRepository.GetAllWithSpecAsync(new ProductIncludesSpecification()); // Using Specification pattern
            if (products != null)
            {
                var mappedProducts = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
                return Ok(mappedProducts);
            }
            return NotFound(new ApiResponse(404, "No products found"));
        }

        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("/api/product/{Id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int Id)
        {
            var product = await _productRepository.GetWithSpecAsync(new ProductIncludesSpecification(Id));
            if (product == null)
            {
                return NotFound(new ApiResponse(404, "Product not found"));
            }
            var mappedProduct = _mapper.Map<Product, ProductDto>(product);
            return Ok(mappedProduct);
        }

        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrandDto>>> GetAllBrands()
        {
            var brands = await _brands.GetAllAsync();
            if (brands == null || !brands.Any())
            {
                return NotFound(new ApiResponse(404, "No brands found"));
            }

            var mappedBrands = _mapper.Map<IReadOnlyList<ProductBrand>, IReadOnlyList<ProductBrandDto>>(brands);
            return Ok(mappedBrands);
        }
        [ProducesResponseType(typeof(ProductCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategoryDto>>> GetAllCategories()
        {
            var categories = await _categories.GetAllAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound(new ApiResponse(404, "No categories found"));
            }

            var mappedCategories = _mapper.Map<IReadOnlyList<ProductCategories>, IReadOnlyList<ProductCategoryDto>>(categories);
            return Ok(mappedCategories);
        }

    }
}
