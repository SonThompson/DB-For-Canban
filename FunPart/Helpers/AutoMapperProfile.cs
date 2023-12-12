using AutoMapper;
using FunPart.Entities;
using FunPart.Models;

namespace FunPart.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<TaskCategories, TaskCategoriesModel>();
            CreateMap<TaskCategoriesModel, TaskCategories>();

            CreateMap<Tasks, TaskModel>();
            CreateMap<TaskModel, Tasks>();

            CreateMap<Users, UserModel>();
            CreateMap<UserModel, Users>();
        }
    }
}
