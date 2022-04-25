using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Models;

namespace finalProject.Models
{
    public class ItemViewModel
    {
        public Item Item { get; set; }
        public HttpPostedFileBase FileBase { get; set; }
    }
}