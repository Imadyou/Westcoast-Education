using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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

    public async Task<List<CategoryViewModel>> ListAllCategoriesAsync()
    {
        return await _context.Categories.ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider).ToListAsync();    
    }
    public async Task<bool> SaveAllAsync()
    {
       return await _context.SaveChangesAsync()>0;
    }
  }
}