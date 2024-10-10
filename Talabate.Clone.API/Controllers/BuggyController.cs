using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabate.Clone.Repository.Data.Contexts;

namespace Talabate.Clone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public BuggyController(StoreDbContext context)
        {
            _context = context;
        }
        [HttpGet("NotFound")] 
        public ActionResult GetNotFoundError()
        {
            var product = _context.Products.Find(100);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("ServrError")]
        public ActionResult GetServerError()
        {
            var product=_context.Products.Find(100);
            var productDto = product.ToString();
            return Ok(productDto);
        }
        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest() {
        return BadRequest();
        }
        [HttpGet("BadRequest/{Id}")]
        public ActionResult GetBadRequest(int Id) {
        return Ok();
        }

        // try to test end point not found
    }
}
