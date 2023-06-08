using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int CartQuantity { get; set; } = 1;
    }
}
