using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CategoriesUpdateDto :BaseDto
    {
        #region  Constructors
        public CategoriesUpdateDto()
        {
            Enabled = true;
        }
        #endregion

        #region Fields

        [Required(ErrorMessage = "CategoryId Required")]
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category Name Required")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }
        #endregion
    }
}
