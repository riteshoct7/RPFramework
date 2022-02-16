using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dtos.Models
{
    public class CitiesCreateDto :BaseDto
    {
        #region Constuctors
        public CitiesCreateDto()
        {
            Enabled = true;
        }
        #endregion

        #region Fields
       
        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name Required")]
        public string CityName { get; set; }

        [Display(Name = "City Description")]
        public string CityDescription { get; set; }
        
        [Display(Name = "States")]
        [Required(ErrorMessage = "States Required")]
        public int StateId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> StatesList { get; set; }
        #endregion
    }
}
