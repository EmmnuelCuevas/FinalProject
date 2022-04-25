using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Category : BaseModel
    {
        public Guid categoryId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [ForeignKey("User")]
        public Guid userId { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual User User { get; set; }
    }
}
