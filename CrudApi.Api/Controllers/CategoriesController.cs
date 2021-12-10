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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if(categories == null)
            {
                return NotFound("Categorias não encontradas");
            }
            return Ok(categories);
        }

        [HttpGet("{id}", Name ="GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int? id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
            return BadRequest("Dados incorretos");

            await _categoryService.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id }, categoryDto);                        
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id)
                return BadRequest();

            if (categoryDto == null)
                return BadRequest();

            await _categoryService.Update(categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound("categoria não encontrada");

            await _categoryService.Remove(id);
            return Ok(category);

        }
    }
}
