using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace omscase.Data.Models
{
    public class Order
    {
        [Key]
        public int orderid { get; set; }

        [ForeignKey("custid")]
        public int customerid { get; set; }


        public  Customer custid { get; set; }



        [Column(TypeName = "varchar(250)")]
        public string  deliveryaddress { get; set; }



        public int totalamount { get; set; }



        [Column(TypeName = "varchar(150)")]
        public string orderstatus { get; set; }
    }
}