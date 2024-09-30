using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Repository.Contruct;

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
           var products=await _productRepository.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            var product = await _productRepository.GetAsync(Id);
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
