using Backend.Application.Contracts;
using Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var product = await service.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(new ProductDto(product));
        }

    }
}
