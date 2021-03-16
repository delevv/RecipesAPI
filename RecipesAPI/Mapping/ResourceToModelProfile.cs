using AutoMapper;
using RecipesAPI.Data.Models;
using RecipesAPI.Resources.Categories;

namespace RecipesAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CategoryInputResource, Category>();
        }
    }
}
