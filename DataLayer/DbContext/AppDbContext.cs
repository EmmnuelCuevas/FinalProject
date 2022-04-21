using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DbContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(): base("FinalProjectDBEntities")
        {

        }


    }
}
