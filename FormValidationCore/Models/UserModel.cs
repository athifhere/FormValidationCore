using System.ComponentModel.DataAnnotations;
using FormValidationCore.Attributes;

namespace FormValidationCore.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm the password")]
        [Compare("Password", ErrorMessage = "The passwords dont match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter contact details")]
        [RegularExpression("^[789]\\d{9}$", ErrorMessage = "Enter the contact details in correct format")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please select your country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please select your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please select your gender")]
        public string Gender { get; set; }

        [ValidateCheckBox(ErrorMessage = "Please accept terms and conditions")]
        public bool AcceptTerms { get; set; }

        public List<string>? CountriesList { get; set; }
    }
}
