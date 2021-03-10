using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace product_crud.Models
{
    public class Product
    {   
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName= "varchar(150)")]
        [Required]
        public String Name { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required]
        public String Brand { get; set; }
    }
}
