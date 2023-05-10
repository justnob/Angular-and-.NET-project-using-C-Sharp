using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers 
{
    
    public class ProductsController : BaseApiController
    {

        public readonly IGenericRepository<Product> ProductsRipo;
        public readonly IGenericRepository<ProductBrand> ProductBrandRipo;
        public readonly IGenericRepository<ProductType> ProductTypeRipo;
        public IMapper Mapper { get; }

        public ProductsController(IGenericRepository<Product> productsRipo, 
        IGenericRepository<ProductBrand> productBrandRipo, IGenericRepository<ProductType> productTypeRipo, 
        IMapper mapper)
        {
            this.Mapper = mapper;
            this.ProductTypeRipo = productTypeRipo;
            this.ProductBrandRipo = productBrandRipo;
            this.ProductsRipo = productsRipo;
            
            
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(){

            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await ProductsRipo.ListAsync(spec);

            return Ok(Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id){

            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product =  await ProductsRipo.GetEntityWithSpec(spec);

            return Mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            return Ok(await ProductBrandRipo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await ProductTypeRipo.ListAllAsync());
        }
        
    }
}