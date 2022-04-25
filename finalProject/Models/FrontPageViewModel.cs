using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Models;

namespace finalProject.Models
{
    public class FrontPageViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Item> Items { get; set; }
    }
}