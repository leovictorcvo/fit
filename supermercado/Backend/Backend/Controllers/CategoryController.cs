using Backend.Application.Contracts;
using Backend.Domain.Models;
using Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll() => 
            await service.GetAllAsync();

        [HttpGet("{id:Guid}/products")]
        public async Task<IEnumerable<ProductDto>> GetProductsByCategory(Guid id)
        {
            var result = await service.GetAllProductsInCategoryAsync(id);
            return result.Select(p => new ProductDto(p));
        }
    }
}
