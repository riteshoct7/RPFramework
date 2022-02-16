using System.ComponentModel.DataAnnotations;

namespace Dtos.ViewModels
{
    public  class RegisterViewModel
    {
        #region Constructors
        public RegisterViewModel()
        {

        }
        #endregion

        #region Fields

        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        #endregion
    }
}
