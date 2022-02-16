using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Categories :BaseEntity
    {
        #region Constructors
        public Categories()
        {
            Enabled = true;            
        }
        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Category Name Required")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }


        public ICollection<Products> Products { get; set; }

        #endregion
    }
}
