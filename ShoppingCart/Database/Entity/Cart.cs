using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Database.Entity
{
    public class Cart
    {
        [Key]
        public Guid id { get; set; }

        public int itemId { get; set; }

        public String itemName {get; set;}

        public int itemQuantity { get; set; }



    }
}
