using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class patientsContext : DbContext
    {
        public patientsContext() : base("myConnectionString")
        {

        }
        public DbSet<patients> patients { get; set; }
    }

   
}
