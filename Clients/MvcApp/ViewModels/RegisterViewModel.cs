using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.ViewModels
{
    public class RegisterViewModel
    {
      
        [Required(ErrorMessage ="E-postadress är obligatorisk!")]
        [Display(Name ="E-postadress")]
        [EmailAddress(ErrorMessage ="Ogiltig mejl adress!")]
         public string?  Email { get; set; }
           [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,20}$",
                    ErrorMessage = "Lösenordet är inte giltigt, det måste vara mellan 8 - 20 tecken och innehålla en siffra, en stor bokstav och symboler")]
         [Required(ErrorMessage ="Lösenord är obligatoriskt!")]
         [Display(Name ="Lösenord")]
   
        public string? Password { get; set; }
          
         [Required(ErrorMessage ="Lösenordsbekräftelse är obligatoriskt!")]
          [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,20}$",
                    ErrorMessage = "Lösenordet är inte giltigt, det måste vara mellan 8 - 20 tecken och innehålla en siffra, en stor bokstav och symboler")]
         [Display(Name ="Lösenordsbekräftelse")]
      
         [Compare("Password",ErrorMessage ="Lösenord och lösenordsbekräftelse är inte lika")]
      
         public string? ConfirmPassword { get; set; }
    }
}