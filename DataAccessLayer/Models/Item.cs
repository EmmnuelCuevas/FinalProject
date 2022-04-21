using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Item : BaseModel
    {
        public Guid itemId { get; set; }
        [ForeignKey("Category")]
        public Guid categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public byte[] image { get; set; }
        public virtual Category Category { get; set; }
    }
}
