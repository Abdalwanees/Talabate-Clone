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

        public ProductsController(IGenaricRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        //BaseUrl/api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            //var products=await _productRepository.GetAllWithSpecAsync(new BaseSpecifications<Product>());//Use Specification design pattern
            var products = await _productRepository.GetAllWithSpecAsync(new ProductIncludesSpecification()); //Use Specification design pattern
            if (products != null)
            {
                var MappedProduct = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
                return Ok(MappedProduct);
            }
            return NotFound(new ApiResponse(404, "Not found any products"));
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int Id)
        {
            var product = await _productRepository.GetWithSpecAsync(new ProductIncludesSpecification(Id));
            if (product == null)
            {
                return NotFound(new ApiResponse(404, "Product Not Found"));
            }
            else
            {
                var MappedProduct = _mapper.Map<Product, ProductDto>(product);
                return Ok(MappedProduct);
            }
        }
    }
}
