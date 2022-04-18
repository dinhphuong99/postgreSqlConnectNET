using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_EF_CRUD_Postgresql.Models;
using System.Data.Entity;

namespace MVC_EF_CRUD_Postgresql.DataContext
{
    public class ApplicationDbContext: DbContext
    {
        //public ApplicationDbContext(): base (nameOrConnectionString: "Myconnection")
        //{

        //}

        public ApplicationDbContext() : base(nameOrConnectionString: "Myconnection")
        {

        }

        public virtual DbSet<EmpClass> Empobj{ get; set; }
    }
}