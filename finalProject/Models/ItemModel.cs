using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Models;

namespace finalProject.Models
{
    public class ItemModel
    {
        public Item Item { get; set; }
        public SelectList Categories { get; set; }
    }
}