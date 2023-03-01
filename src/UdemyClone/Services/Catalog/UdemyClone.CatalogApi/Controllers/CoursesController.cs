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
	internal class CoursesController : CustomBaseController
	{
		private readonly ICourseService _courseService;

		internal CoursesController(ICourseService courseService)
		{
			_courseService = courseService;
		}
		public async Task<IActionResult> GetAll()
		{
			var response = await _courseService.GetAllAsync();

			return CreateActionResultInstance(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(string id)
		{
			var response = await _courseService.GetByIdAsync(id);

			return CreateActionResultInstance(response);
		}

		[Route("api/[controller]/GetAllByUserId/{userid}")]
		public async Task<IActionResult> GetAllByUserId(string userid)
		{
			var response = await _courseService.GetAllByUserIdAsync(userid);

			return CreateActionResultInstance(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
		{
			var response = await _courseService.CreateAsync(courseCreateDto);

			return CreateActionResultInstance(response);
		}	
		
		[HttpPut]
		public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
		{
			var response = await _courseService.UpdateAsync(courseUpdateDto);

			return CreateActionResultInstance(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			var response = await _courseService.DeleteAsync(id);

			return CreateActionResultInstance(response);
		}
	}
}
