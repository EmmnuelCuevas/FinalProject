using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            id = Guid.NewGuid();
            createdOn = DateTime.Now;
        }
        [Required]
        public Guid id { get; set; }

        public DateTime createdOn { get; set; }


    }
}
