using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.ViewModels.Category
{
    public class PostCategoryViewModel
    {
        [Required]
        public string? Name { get; set; }
    }
}