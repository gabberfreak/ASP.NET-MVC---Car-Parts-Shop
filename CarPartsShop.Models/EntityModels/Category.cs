using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarPartsShop.Models.EntityModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
