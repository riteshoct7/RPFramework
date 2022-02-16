using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class StatesListDto :BaseDto
    {
        #region Constructors
        public StatesListDto()
        {
            
        }
        #endregion

        #region Fields
        
        public int StateId { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "State Name Required")]
        public string StateName { get; set; }

        [Display(Name = "State Description")]
        public string StateDescription { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public CountriesListDto Countries { get; set; }


        #endregion
    }
}
