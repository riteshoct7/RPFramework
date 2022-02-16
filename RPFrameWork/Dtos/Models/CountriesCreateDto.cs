
using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CountriesCreateDto :BaseDto
    {
        #region  Constructors
        public CountriesCreateDto()
        {
            Enabled = true;
        }
        #endregion
        
        #region Fields
        
        [Required(ErrorMessage = "Country Name Required")]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Country Description")]
        public string CountryDescription { get; set; }

        [Display(Name = "ISD Code")]
        public string ISDCode { get; set; }

        #endregion        
    }
}
