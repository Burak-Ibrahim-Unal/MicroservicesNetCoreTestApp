using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.CatalogApi.Dtos;
using UdemyClone.CatalogApi.Models;
using UdemyClone.CatalogApi.Settings;
using UdemyClone.Shared.Dtos;

namespace UdemyClone.CatalogApi.Services
{
	internal class CourseService
	{
		private readonly IMongoCollection<Course> _courseCollection;
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMapper _mapper;

		public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);

			_courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
			_categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
			_mapper = mapper;
		}

		public async Task<Response<List<CourseDto>>> GetAllAsync()
		{
			var courses = await _courseCollection.Find(course => true).ToListAsync();
			if (courses.Any())
			{
				foreach (var course in courses)
				{
					course.Category = await _categoryCollection.Find<Category>(category => category.Id == course.CategoryId).FirstAsync();
				
				}
			}
		}


	}
}
