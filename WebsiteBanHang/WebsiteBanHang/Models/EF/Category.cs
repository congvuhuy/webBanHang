using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models.EF
{
    [Table("tb_Category")]
    public class Category:CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<New>();
            
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Tile { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTile { get; set; }
        public string SeoKeywords { get; set; }
        public ICollection<New> News { get; set; }
        public ICollection<Post> Posts { get; set; }
        
    }
}