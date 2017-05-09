using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Data.Model
{
    public class Products
    {
        [Key]
        public Int32 ProductId { get; set; }

        public String ProductName { get; set; }
    }
}
