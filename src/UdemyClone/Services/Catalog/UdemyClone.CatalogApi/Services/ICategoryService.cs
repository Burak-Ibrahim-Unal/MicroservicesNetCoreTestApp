using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyClone.CatalogApi.Dtos;
using UdemyClone.CatalogApi.Models;
using UdemyClone.Shared.Dtos;

namespace UdemyClone.CatalogApi.Services
{
	public interface ICategoryService
	{
		Task<Response<List<CategoryDto>>> GetAllAsync();
		Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
		Task<Response<CategoryDto>> GetByIdAsync(string id);

	}
}
