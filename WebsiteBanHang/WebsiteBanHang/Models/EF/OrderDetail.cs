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
        [Column(Order = 0)]
        public int OrderID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual Product Products { get; set; }
        public virtual Order Order { get; set; }
        
    }
}