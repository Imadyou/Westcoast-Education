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
     var cat = _mapper.Map<Category>(model);
     await _context.Categories.AddAsync(cat);
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

    public async Task <List<CategoriesWithCoursesViewModel>> ListCategoriesAndCoursesAsync()
    {
        return await _context.Categories.Include(c=>c.Courses)
        .Select(ca => new CategoriesWithCoursesViewModel{
            Name=ca.Name,
            Courses =ca.Courses
            .Select(co =>new CourseByCategoryViewModel{
                Id=co.Id,
                Title=co.Title,
                Duration=co.Duration
            }).ToList()
        }).ToListAsync();
    }

    // public async Task<CategoriesWithCoursesViewModel?> ListCategoryCoursesAsync(int id)
    // {
    //       return await _context.Categories.Where(ca=>ca.Id==id).Include(c=>c.Courses)
    //     .Select(cat => new CategoriesWithCoursesViewModel{
    //         Name=cat.Name,
    //         Courses =cat.Courses
    //         .Select( co =>new CourseByCategoryViewModel{
    //         Id=co.Id,
    //         Title=co.Title,
    //         Duration=co.Duration
    //     }).ToList()
    // }).SingleOrDefaultAsync();
    // }
    //   public async Task<CategoriesWithCoursesViewModel?> ListCoursesByCategoriAsync(string subject)
    // {
    //       return await _context.Categories.Where(ca=>ca.Name==subject).Include(c=>c.Courses)
    //     .Select(c => new CategoriesWithCoursesViewModel{
    //         Name=c.Name,
    //         Courses =c.Courses
    //         .Select( c =>new CourseByCategoryViewModel{
    //         Id=c.Id,
    //         Title=c.Title,
    //         Duration=c.Duration
            
    //     }).ToList()
    // }).SingleOrDefaultAsync();
    // }

    public async Task<bool> SaveAllAsync()
    {
       return await _context.SaveChangesAsync()>0;
    }
  }
}