using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dtos.Models
{
    public class StatesCreateDto : BaseDto
    {
        #region Constructors
        public StatesCreateDto()
        {
            Enabled = true;
        }
        #endregion

        #region Fields
        
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "State Name Required")]
        public string StateName { get; set; }

        [Display(Name = "State Description")]
        public string StateDescription { get; set; }
        
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Required")]
        public int CountryId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CountriesList { get; set; }

        #endregion
    }
}
