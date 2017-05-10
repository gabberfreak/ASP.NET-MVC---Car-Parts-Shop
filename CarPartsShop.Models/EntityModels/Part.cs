using CarPartsShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPartsShop.Models.EntityModels
{
    public class Part
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }
        public PartCondition Condition { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderedParts> OrderedParts { get; set; }
    }
}
