using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dtos.Models
{
    public class CitiesUpdateDto : BaseDto
    {
        #region Constuctors
        public CitiesUpdateDto()
        {
            Enabled = true;
        }
        #endregion

        #region Fields

        [Required(ErrorMessage = "CityId Required")]
        public int CityId { get; set; }

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
