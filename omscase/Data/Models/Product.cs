using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace omscase.Data.Models
{
    public class Product
    {
        [Key]
        public int productid { get; set; }


        [Column(TypeName = "varchar(250)")]
        public string title { get; set; }
        public int price { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string image { get; set; }


        [Column(TypeName = "varchar(350)")]
        public string product_description { get; set; }
    }
}
