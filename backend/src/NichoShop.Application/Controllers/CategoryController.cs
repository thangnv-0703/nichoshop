using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NichoShop.Application.Helpers;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.ViewModels;
using System.Net;

namespace NichoShop.Application.Controllers;

[Route("api/v1/categories")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategory()
    {
        var result = await _categoryService.GetCategoryAsync();
        return Ok(result);
    }
}
