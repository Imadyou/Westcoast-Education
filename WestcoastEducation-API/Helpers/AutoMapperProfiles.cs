using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
        CreateMap<PostCourseViewModel, Course>()
        .ForMember(dest=> dest.Id, options => options.MapFrom(src =>src.CourseId)).ForMember(dest=> dest.Title, options=> options.MapFrom(src=> src.CourseTitle)).ForMember(dest=>dest.Duration, options=>options.MapFrom(src=>src.CourseDuration));

        CreateMap<Course, CourseViewModel>() .ForMember(dest=> dest.CourseDuration, options => options.MapFrom(src =>src.Duration));

        CreateMap<PostCategoryViewModel, Category>();
        CreateMap<Category, CategoryViewModel>();
        // .ForMember(dest=>dest.CategoryId, Options => Options.MapFrom(Src=> Src.Id));
    }
  }
}