using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("FinalProjectDBEntities")
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<DataAccessLayer.Models.User> Users { get; set; }
    }
}
