using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class ProductsListDto : BaseDto
    {
        #region Constructors
        public ProductsListDto()
        {

        }
        #endregion

        #region Fields
        
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        
        [Display(Name = "Price")]        
        public double UnitPrice { get; set; }


        [Display(Name = "Catgeory")]
        public int CategoryId { get; set; }

        public CategoriesListDto Categories { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        #endregion
    }
}
