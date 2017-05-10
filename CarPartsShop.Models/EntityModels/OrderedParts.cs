using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPartsShop.Models.EntityModels
{
    public class OrderedParts
    {
        [Key]
        [Column(Order = 0)]
        public int PartId { get; set; }

        public virtual Part Part{ get; set; }

        [Key]
        [Column(Order = 1)]
        public int CustomerOrderId { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; }

        public int Quantity { get; set; }
        

    }
}
