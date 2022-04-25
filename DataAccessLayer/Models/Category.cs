using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Category : BaseModel
    {
        public Guid categoryId { get; set; }
        [Required]
        public string name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
