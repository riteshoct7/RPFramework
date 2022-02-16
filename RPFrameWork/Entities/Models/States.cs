using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class States :BaseEntity
    {
        #region Constructors
        public States()
        {
            Enabled = true;
        }
        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage =  "State Name Required")]
        public string StateName { get; set; }

        [Display(Name ="State Description")]
        public string StateDescription { get; set; }

        [ForeignKey("Countries")]
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Required")]
        public int CountryId { get; set; }

        public Countries Countries { get; set; }

        public ICollection<Cities> Cities { get; set; }

        #endregion
    }
}
