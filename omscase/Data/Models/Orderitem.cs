using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace omscase.Data.Models
{
    public class Orderitem
    {
        [Key]
        public int specific_id { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string order_status { get; set; }

       
        [ForeignKey("orderid")]
        public int order_id { get; set; }
       
        public Order orderid{ get; set; }

        public int quantity { get; set; }
        public int price { get; set; }


        [ForeignKey("productid")]
        public int prodid { get; set; }
        public Product productid { get; set; }

    }
}
