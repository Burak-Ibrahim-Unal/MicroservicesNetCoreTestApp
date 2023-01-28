using AutoMapper;
using UdemyClone.CatalogApi.Dtos;
using UdemyClone.CatalogApi.Models;

namespace UdemyClone.CatalogApi.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{

			CreateMap<Course, CourseDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Feature, FeatureDto>().ReverseMap();

			CreateMap<Course, CourseCreateDto>().ReverseMap();
			CreateMap<Course, CourseUpdateDto>().ReverseMap();
		}
	}
}
