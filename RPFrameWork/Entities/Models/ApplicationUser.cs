using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ApplicationUser :IdentityUser<int>
    {
        #region Constructors
        public ApplicationUser()
        {

        }
        #endregion

        #region Fields

        [Display(Name ="First Name")]
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage ="Last Name Required")]
        public string LastName { get; set; }

        [NotMapped]
        public string[] ApplicationRoles { get; set; }

        #endregion
    }
}
