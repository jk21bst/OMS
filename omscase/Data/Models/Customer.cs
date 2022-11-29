using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace omscase.Data.Models
{
    public class Customer
    {
       
        [Key]
        public int custid { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string username { get; set; }


        [Column(TypeName = "varchar(250)")]
        public string password { get; set; }


        [Column(TypeName = "varchar(250)")]
        public string custname { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string gender { get; set;}


        [Column(TypeName = "varchar(250)")]
        public string custaddress { get; set; }



        public int mobileno { get; set; }
    }
}
