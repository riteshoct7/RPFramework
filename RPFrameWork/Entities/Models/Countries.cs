using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class Countries : BaseEntity
    {
        #region Constructors
        public Countries()
        {
            Enabled = true;
        }
        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Country Name Required")]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Country Description")]
        public string CountryDescription { get; set; }


        [Display(Name = "ISD Code")]
        public string ISDCode { get; set; }

        public ICollection<States> States { get; set; }

        #endregion
    }
}
