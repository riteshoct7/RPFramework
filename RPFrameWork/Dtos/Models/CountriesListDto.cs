using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CountriesListDto :BaseDto
    {
        #region Constructors
        public CountriesListDto()
        {

        }
        #endregion

        #region Fields
        
        public int CountryId { get; set; }
        
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Country Description")]
        public string CountryDescription { get; set; }

        [Display(Name = "ISD Code")]
        public string ISDCode { get; set; }

        #endregion
    }
}
