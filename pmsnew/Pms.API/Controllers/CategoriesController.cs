using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pms.Core;
using Pms.Core.Dtos;
using Pms.Core.Services;

namespace Pms.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]

public class CategoriesController : CustomBaseController
{
    private readonly IMapper _mapper;
    private readonly ICategoryService _service;

    public CategoriesController(IMapper mapper, ICategoryService service)
    {
        _mapper = mapper;
        _service = service;
    }
    [HttpGet("[action]/{categoryId}")]
    public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int categoryId)
    {
        return CreateActionResult(await _service.GetSingleCategoryByIdWithProductsAsync(categoryId));
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> AllCategories()
    {
        var categories = await _service.GetAllAsync();
        var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);
        return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDtos));
    }
    [HttpGet("[action]/{categoryId}")]
    public async Task<IActionResult> GetByIdCategory(int id)
    {
        var categories = await _service.GetByIdAsync(id);
        var categoriesDtos = _mapper.Map<CategoryDto>(categories);
        return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoriesDtos));
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> SaveCategory(CategoryDto categoriesDto)
    {
        var categories = await _service.AddAsync(_mapper.Map<Category>(categoriesDto));
        var categoriesDtos = _mapper.Map<CategoryDto>(categories);
        return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoriesDtos));
    }
    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateCategory(CategoryDto categoriesDto)
    {
        await _service.UpdateAsync(_mapper.Map<Category>(categoriesDto));
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
    [HttpDelete("[action]/{categoryId}")]
    public async Task<IActionResult> RemoveCategory(int id)
    {
        var category = await _service.GetByIdAsync(id);
        await _service.RemoveAsync(category);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

}

