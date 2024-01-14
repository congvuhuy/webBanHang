using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public class CommonAbstract
    {
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifierDate { get; set; }
        public string ModifierBy { get; set; }
    }
}