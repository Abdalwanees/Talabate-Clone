using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Repository.Contruct;
using Talabate.Clone.Core.Specifications;
using Talabate.Clone.Core.Specifications.ProductSpecifications;

namespace Talabate.Clone.API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IGenaricRepository<Product> _productRepository;

        public ProductsController(IGenaricRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        //BaseUrl/api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
           //var products=await _productRepository.GetAllWithSpecAsync(new BaseSpecifications<Product>());//Use Specification design pattern
           var products=await _productRepository.GetAllWithSpecAsync(new ProductIncludesSpecification()); //Use Specification design pattern
            return Ok(products);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            var product = await _productRepository.GetWithSpecAsync(new ProductIncludesSpecification());
            if (product == null)
            {
                return NotFound(new {Message="Not Found product",StatusCode=404});
            }
            else
            {
                return Ok(product);
            }
        }
     }
}
