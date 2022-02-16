using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CountriesUpdateDto :BaseDto
    {
        #region  Constructors
        public CountriesUpdateDto()
        {
            Enabled = true;
        }
        #endregion

        #region Fields

        [Required(ErrorMessage = "CountryId Required")]
        public int CountryId { get; set; }

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
