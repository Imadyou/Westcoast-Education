using AutoMapper;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Repositories
{
  public class CategoriesRepository : ICategoriesRepository

  {
    private readonly IMapper _mapper;
    private readonly CourseContext _context;
    public CategoriesRepository( CourseContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task AddCategoryAsync(PostCategoryViewModel model)
    {
     var cat = _mapper.Map<Category>(model);
     await _context.Categories.AddAsync(cat);
    }

    public Task<List<CategoryViewModel>> ListAllcategoriesAsync()
    {
      throw new NotImplementedException();
    }
  }
}