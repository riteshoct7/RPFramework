using System.ComponentModel.DataAnnotations;

namespace Dtos.ViewModels
{
    public class LoginViewModel
    {
        #region Constructors
        public LoginViewModel()
        {

        }
        #endregion

        #region Fields
        [Required(ErrorMessage = "UserName Required")]
        [Display(Name = "User Name")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remembe Me")]
        public bool RemembeMe { get; set; } 
        #endregion
    }
}
