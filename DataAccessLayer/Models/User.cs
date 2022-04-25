using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class User : BaseModel
    {
        [Required]
        public string name { get; set; }
        public string lastName { get; set; }

        public string fullName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
