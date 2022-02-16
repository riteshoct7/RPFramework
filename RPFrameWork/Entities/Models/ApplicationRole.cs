using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class ApplicationRole :IdentityRole<int>
    {
        #region Constructors
        public ApplicationRole()
        {

        }
        #endregion

        #region Fields

        [Required(ErrorMessage ="Description Required")]
        [Display(Name = "Description Required")]
        public string Description { get; set; }

        #endregion
    }
}
