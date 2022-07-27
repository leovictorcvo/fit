using Backend.Application.Contracts;
using Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController: ControllerBase
    {
        private readonly ICartService service;

        public CartController(ICartService service)
        {
            this.service = service;
        }

        [HttpGet("{id:Guid}")]
        public async Task<CartDto> GetCart(Guid id)
        {
            var cart = await service.GetCart(id);
            return new CartDto(cart);
        }

        [HttpPost]
        public async Task<CartDto> AddItemToCart(CartItemToAddDto item)
        {
            var cart = await service.AddItemToCart(item.CartId, item.ProductId, item.Quantity);
            return new CartDto(cart);
        }
    }
}
