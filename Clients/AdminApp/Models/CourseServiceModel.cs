using System.Reflection;
using System.Text.Json;
using AdminApp.ModelsView;
using AdminApp.ModelsView.Course;

namespace AdminApp.Models
{
    public class CourseServiceModel
    {
        private readonly IConfiguration _config;

        private readonly JsonSerializerOptions _options;
        public CourseServiceModel(IConfiguration config)
        {
            _config = config;
            _options = new JsonSerializerOptions();

        }
        public async Task<List<CourseViewModel>> ListCoursesFull()
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/fullList";
            using var http = new HttpClient();
            var response = await http.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("kunde inte hämta paketet från API application");
            }
            var courses = await response.Content.ReadFromJsonAsync<List<CourseViewModel>>();
            return courses ?? new List<CourseViewModel>();

        }
        public async Task<bool> AddCourse(PostCourseViewModel model)
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/{model}";
            using var http = new HttpClient();
            var response = await http.PostAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                return false;
                throw new Exception("Något gick fel när vi skulle spara kursen");
            }
             var courses = await response.Content.ReadFromJsonAsync<List<CourseViewModel>>();

            return true;

        }
        public async Task<bool> UpdateCourse(int id, PutCourseViewModel model)
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/{id}";
            using var http = new HttpClient();
            var response = await http.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return false;
                throw new Exception($"Vi Hittar inte kursen med Id:{id}");
            }
            var courseToAdd = await response.Content.ReadFromJsonAsync<CourseViewModel>();
            model.CourseId = id;
            model.CourseTitle = courseToAdd!.Title; 
            model.Subject = courseToAdd.Subject;
            model.Details = courseToAdd.Details;  
            model.CourseDuration = courseToAdd.CourseDuration;
            model.Description=courseToAdd.Description;
            var addCourse = await http.PostAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                return false;
                throw new Exception("Något gick fel när vi skulle spara kursen");
            }
            return true;
        } 
        public async Task<bool> DeleteCourse(int id)
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/{id}";
            using var http = new HttpClient();
            var response = await http.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return false;
                throw new Exception($" kursen med Id:{id} finns inte!");
            }
            else {
                var urlDelete = $"{baseUrl}/Courses/delete/{id}";
                using var http1 = new HttpClient();
                var deleteCourse = await http.PostAsJsonAsync(url, id);
                if (deleteCourse.IsSuccessStatusCode)

                    return true;
            }
            return true;

        }
        
    }



    }

