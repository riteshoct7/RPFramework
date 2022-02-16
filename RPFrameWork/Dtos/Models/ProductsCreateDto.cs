﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class ProductsCreateDto : BaseDto
    {
        #region Constructors
        public ProductsCreateDto()
        {
            Enabled = true;
        }
        #endregion

        #region Fields
        
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Categories Required")]
        public int CategoryId { get; set; }
       
        [Required(ErrorMessage = "Price Required")]
        [Display(Name = "Price")]
        [Range(1, 500000)]
        public double UnitPrice { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }

        #endregion
    }
}
