using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models.EF
{
    [Table("tb_OrderDetail")]
    public class OrderDetail
    {
        public OrderDetail()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public ICollection<Product>  Products { get; set; }
    }
}