using CarPartsShop.Models.EntityModels;
using System.Collections.Generic;

namespace CarPartsShop.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
