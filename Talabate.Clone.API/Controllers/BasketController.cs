using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabate.Clone.API.DTOs;
using Talabate.Clone.API.Errors;
using Talabate.Clone.Core.Entites.Busket;
using Talabate.Clone.Core.Repository.Contruct;

namespace Talabate.Clone.API.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository ,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet("{Id}")] //Get :~/api/Basket/Id
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket=await _basketRepository.GetBasketAsync(id);

            return Ok(basket ??new CustomerBasket(id));
        
        }
         
        [HttpPost]  //Post :~/api/basket
        public async Task<ActionResult<CustomerBasket>> AddOrUpdateBasket(CustomerBasketDto basket)
        {
            var MappedBasket=_mapper.Map<CustomerBasketDto,CustomerBasket>(basket);
            var createOrUpdatabasket = await _basketRepository.UpdatetAsync(MappedBasket);
            if (createOrUpdatabasket == null) return BadRequest(new ApiResponse(400));
            return Ok(createOrUpdatabasket);
        }
        [HttpDelete] //Delete :~/api/Basket
        public async Task DeleteBasket(string id)
        {
             await _basketRepository.DeleteBasketAsync(id);

        }

    }
}
