using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Category : BaseModel
    {
        public Guid categoryId { get; set; }
        public string name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
