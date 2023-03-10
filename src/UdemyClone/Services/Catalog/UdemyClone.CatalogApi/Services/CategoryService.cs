using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyClone.CatalogApi.Dtos;
using UdemyClone.CatalogApi.Models;
using UdemyClone.CatalogApi.Settings;
using UdemyClone.Shared.Dtos;

namespace UdemyClone.CatalogApi.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMapper _mapper;

		public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);

			_categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
			_mapper = mapper;
		}

		public async Task<Response<List<CategoryDto>>> GetAllAsync()
		{
			var categories = await _categoryCollection.Find(category => true).ToListAsync();
			return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
		}

		public async Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto)
		{
			var newCategory = _mapper.Map<Category>(categoryCreateDto);
			await _categoryCollection.InsertOneAsync(newCategory);

			return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(newCategory), 200);
		}

		public async Task<Response<CategoryDto>> GetByIdAsync(string id)
		{
			var category = await _categoryCollection.Find<Category>(c => c.Id == id).FirstOrDefaultAsync();
			if (category == null) return Response<CategoryDto>.Fail("Category is not found", 404);

			return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
		}
	}
}
