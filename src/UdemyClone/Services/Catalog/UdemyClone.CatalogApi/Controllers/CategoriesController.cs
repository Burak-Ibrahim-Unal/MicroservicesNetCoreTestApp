using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UdemyClone.CatalogApi.Dtos;
using UdemyClone.CatalogApi.Services;
using UdemyClone.Shared.CustomControllers;

namespace UdemyClone.CatalogApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : CustomBaseController
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var categories = await _categoryService.GetAllAsync();

			return CreateActionResultInstance(categories);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(string id)
		{
			var categories = await _categoryService.GetByIdAsync(id);

			return CreateActionResultInstance(categories);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
		{
			var response = await _categoryService.CreateAsync(categoryCreateDto);

			return CreateActionResultInstance(response);
		}
	}
}
