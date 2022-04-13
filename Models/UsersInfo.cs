using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Models
   
{
    public class UsersInfo
    {
        public List<UsersInfo> ListOfUsers = new List<UsersInfo>();
       

        [Display(Name = "First name")]
        [RegularExpression(@"[A-Z]{1,1}[a-z]+", ErrorMessage = "Start typing your first name with large letter and continue using small ones")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Length of field First name can't be less 2 and more 20")]
        public string FName { get; set; }
        [Display(Name = "Last name")]
        [RegularExpression(@"[A-Z]{1,1}[a-z]+", ErrorMessage = "Start typing your last name with large letter and continue using small ones")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Length of field Last name can't be less 2 and more 30")]
        public string LName { get; set; }


        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }
        [Required(ErrorMessage = "Mention your gender")]
       
        public string Gender { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Incorrect Email address")]
        [Remote(action: "CheckEmail", controller: "Mockups", ErrorMessage = "Account with such email has already registered")]
        public string EMail { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Incorrect Email address")]
        [Remote(action: "CheckEmailReset", controller: "Mockups", ErrorMessage = "Account with such email has not registered yet")]
        public string EMailForReset { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Length of your password can't be less 6 and more 30")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Values in fields Password and Confirm password are different")]
        public string PasswordConfirm { get; set; }
        
        public string Remembered { get; set; }
     
    }
}
