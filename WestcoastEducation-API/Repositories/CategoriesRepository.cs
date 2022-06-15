using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels;
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
      
     var categories= await _context.Categories.ToListAsync();
     foreach (var cat in categories)
     {
      if (cat.Name==model.Name)
      {
        throw new Exception($"Kategorin {model.Name} fnns redan i vå kategori lista");
      }
      
     }
     var catToAdd = _mapper.Map<Category>(model);

     await _context.Categories.AddAsync(catToAdd);
    }

    public async Task DeleteCategoryAsync(int id)
    {
      var result= await _context.Categories.FindAsync(id);
      if(result is null)
      {
      throw new Exception($"Kunde inte hitta kategori med Id: {id}");
      }
      _context.Categories.Remove(result);
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