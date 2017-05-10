using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPartsShop.Models.EntityModels
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public string CartId { get; set; }

        public int Count { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        public int PartId { get; set; }

        public virtual Part Part { get; set; }
    }
}
