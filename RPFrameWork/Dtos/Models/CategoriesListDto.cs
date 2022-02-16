using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CategoriesListDto :BaseDto
    {
        #region  Constructors
        public CategoriesListDto()
        {

        }
        #endregion

        #region Fields
        
        public int CategoryId { get; set; }
        
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }
        #endregion
    }
}
