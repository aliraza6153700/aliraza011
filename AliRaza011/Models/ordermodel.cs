using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AliRaza011.Models
{
    public class ordermodel
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        [Required]
        public int dis_quantity { get; set; }
        public int price { get; set; }

    }
}
