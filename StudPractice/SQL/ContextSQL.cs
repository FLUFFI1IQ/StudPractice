using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;

namespace StudPractice.SQL
{
    public class ContextSQL : DbContext
    {
        public DbSet<Login> Logins { get; set; }
    }
}
