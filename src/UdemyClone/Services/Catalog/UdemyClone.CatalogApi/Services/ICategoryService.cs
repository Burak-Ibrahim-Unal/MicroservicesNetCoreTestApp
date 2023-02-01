using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyClone.CatalogApi.Dtos;
using UdemyClone.CatalogApi.Models;
using UdemyClone.Shared.Dtos;

namespace UdemyClone.CatalogApi.Services
{
	internal interface ICategoryService
	{
		Task<Response<List<CategoryDto>>> GetAllAsync();
		Task<Response<CategoryDto>> CreateAsync(Category category);
		Task<Response<CategoryDto>> GetByIdAsync(string id);

	}
}
