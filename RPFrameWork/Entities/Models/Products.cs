using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class Products : BaseEntity
    {
        #region Constructors
        public Products()
        {
            Enabled = true;
        }
        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [ForeignKey("Categories")]
        [Display(Name = "Categories")]
        [Required(ErrorMessage = "Categories Required")]
        public int CategoryId { get; set; }

        public Categories Categories { get; set; }

        [Required(ErrorMessage ="Price Required")]
        [Display(Name ="Price")]
        [Range(1,500000)]
        public double UnitPrice { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        #endregion
    }
}
