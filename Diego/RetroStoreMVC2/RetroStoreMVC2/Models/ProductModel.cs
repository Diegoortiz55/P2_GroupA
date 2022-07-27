using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace RetroStoreMVC2.Models
{
    public class ProductModel
    {
        [Display(Name = "Id")]
        public int? productId { get; set; }
        [Display(Name = "Name")]
        public string? productName { get; set; }
        [Display(Name = "Type")]
        public string? productType { get; set; }
        [Display(Name = "Genre")]
        public string? productGenre { get; set; }
        [Display(Name = "Platform")]
        public string? productPlatform { get; set; }
        [Display(Name = "Developer")]
        public string? productManufacturer { get; set; }
        [Display(Name = "Release Date")]
        public int? productReleaseDate { get; set; }
        [Display(Name = "Cost")]
        //[System.ComponentModel.DataAnnotations.Range(100,2000,ErrorMessage = "Please enter value between 100 and 2000")] - form of validation
        public float? productCost { get; set; }
        [Display(Name = "Available Quantity")]
        public int? productQty { get; set; }
        [Display(Name = "In Stock")]
        public bool? productIsInStock { get; set; }
    }
}

