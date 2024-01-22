using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models.EF
{
    [Table("tb_Product")]
    public class Product:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [StringLength(50)]
        public string ProductCode { get; set; }
        public int ProductCategoryID { get; set; }
        [StringLength(250)]
        public string Alias { get; set; }
        public string Description { get; set; }
        [AlowHtml]
        public string Detail { get; set; }
        [StringLength(250)]

        public string Image { get; set; }
        public Decimal Price { get; set; }
        public Decimal PriceSale { get; set; }
        public int Quantity { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeture { get; set; }
        public bool IsHot { get; set; }
        [StringLength(500)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }

    }
}