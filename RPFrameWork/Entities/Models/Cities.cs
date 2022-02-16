using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Cities :BaseEntity
    {
        #region Constructors
        public Cities()
        {
            Enabled = true;
        }
        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name Required")]
        public string CityName { get; set; }

        [Display(Name = "City Description")]
        public string CityDescription { get; set; }

        [ForeignKey("States")]
        [Display(Name = "States")]
        [Required(ErrorMessage = "States Required")]
        public int StateId { get; set; }

        public States States { get; set; }

        #endregion
    }
}
