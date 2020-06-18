
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specification;
using api.Dtos;
using AutoMapper;
using api.Errors;
using Microsoft.AspNetCore.Http;

namespace api.Controllers
{  
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Products> productRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<ProductType> productTypeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Products> productRepo
            , IGenericRepository<ProductBrand> productBrandRepo
            , IGenericRepository<ProductType> productTypeRepo
            , IMapper mapper)
        {
            this.productRepo = productRepo;
            this.productBrandRepo = productBrandRepo;
            this.productTypeRepo = productTypeRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductTypeandBrandSpecification();
            var product = await this.productRepo.ListAsync(spec);
            return Ok(mapper
                    .Map<IReadOnlyList<Products>, IReadOnlyList<ProductToReturnDto>>(product));
           
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductTypeandBrandSpecification(id);
            var prodResult = await this.productRepo.GetEntityWithSpec(spec);

            if (prodResult == null) return NotFound(new ApiResponse(404));

            return mapper.Map<Products, ProductToReturnDto>(prodResult);                        
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            return Ok(await this.productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
            return Ok(await this.productTypeRepo.ListAllAsync());
        }
    }
}