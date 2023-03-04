using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UdemyClone.CatalogApi.Dtos;
using UdemyClone.CatalogApi.Models;
using UdemyClone.Shared.Dtos;

namespace UdemyClone.CatalogApi.Services
{
	public interface ICourseService
	{
		Task<Response<List<CourseDto>>> GetAllAsync();

		Task<Response<CourseDto>> GetByIdAsync(string id);

		Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);

		Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);

		Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);

		Task<Response<NoContent>> DeleteAsync(string id);
	}
}
