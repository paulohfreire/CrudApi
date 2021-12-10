using CrudApi.Application.DTOs;
using CrudApi.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();
            if (products == null)
            {
                return NotFound("Produtos não encontrados");
            }
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int? id)
        {
            var produto = await _productService.GetById(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
                return BadRequest("Dados incorretos");

            await _productService.Add(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id)
                return BadRequest();

            if (productDto == null)
                return BadRequest();

            await _productService.Update(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound("categoria não encontrada");

            await _productService.Remove(id);
            return Ok(product);

        }

    }
}
