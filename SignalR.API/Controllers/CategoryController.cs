﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult CategoryList()
    {
        var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll()); 
        return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
    {
        _categoryService.TAdd(new Category()
        {
            CategoryName = createCategoryDto.CategoryName,
            Status = true,
        });
        return Ok("Kategoryi eklendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var values = _categoryService.TGetByID(id);
        _categoryService.TDelete(values);
        return Ok("Kategori silindi.");
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        var values = _categoryService.TGetByID(id);
        return Ok(values);
    }
    [HttpPut]
    public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        _categoryService.TUpdate(new Category()
        {
            CategoryName = updateCategoryDto.CategoryName,
            CategoryID = updateCategoryDto.CategoryID,
            Status = updateCategoryDto.Status
        });
        return Ok("Kategori güncellendi.");
    }
}
