using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CitiesListDto : BaseDto
    {
        #region Constuctors
        public CitiesListDto()
        {
            
        }
        #endregion


        #region Fields
        
        public int CityId { get; set; }

        [Display(Name = "City Name")]        
        public string CityName { get; set; }

        [Display(Name = "City Description")]
        public string CityDescription { get; set; }

        [Display(Name = "State")]
        public int StateId { get; set; }

        public StatesListDto States { get; set; }

        #endregion
    }
}
