using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CategoriesCreateDto :BaseDto
    {
        #region  Constructors
        public CategoriesCreateDto()
        {
            Enabled = true;
        }
        #endregion

        #region Fields
        
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category Name Required")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }
        #endregion
    }
}
