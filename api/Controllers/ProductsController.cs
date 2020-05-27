
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var Products = await this._context.Products.ToListAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            return await this._context.Products.FindAsync(id);
        }
    }
}