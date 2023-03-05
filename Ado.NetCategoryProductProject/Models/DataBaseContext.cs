using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ado.NetCategoryProductProject.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }    
    }
}