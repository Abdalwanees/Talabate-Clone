using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabate.Clone.API.DTOs;
using Talabate.Clone.API.Errors;
using Talabate.Clone.Core.Entites.Order.Aggregrate;
using Talabate.Clone.Core.Services.Contruct;
using Talabate.Clone.Repository.Data.Migrations;

namespace Talabate.Clone.API.Controllers
{

    public class OrdersController : BaseController
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService service ,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [ProducesResponseType(typeof(Order),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status400BadRequest)]
        [HttpPost] //Post : ~/api/Orders
        public async Task<ActionResult<Order>> CreateOrder(OrderDto order)
        {
            var address=_mapper.Map<AddressDto,Address>(order.ShippingAddress);
            var orderCreated = await _service.CreateOrderAsync(order.BuyerEmail, order.BusketId, order.DelivaryMethod, address);
            if (orderCreated == null) return BadRequest(new ApiResponse(400));
            return Ok(_mapper.Map<Order,OrderToReturnDto>(orderCreated));
        }

        //Get Order For Specific User
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Order>>> GetOrdersForUser(string userEmail)
        {
            //Get Order For User
            var orders=await _service.GetOrdersForUserAsync(userEmail);
            if (orders == null) return BadRequest(new ApiResponse(404, "Not Found Orders For this User"));
            return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders));
        }
        //Get Specific Order For specific User
        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order?>> GetOrderForUser([FromRoute]int orderId,string userEmail)
        {
            //Get Order For User
            var order = await _service.GetOrderByIdForUserAsync( orderId,userEmail);
            if (order == null) return BadRequest(new ApiResponse(404, "Not Found Order For this User"));
            return Ok(_mapper.Map<Order, OrderToReturnDto>(order));
        }
    }
}
