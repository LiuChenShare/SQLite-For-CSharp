using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Test_1_简单测试
{
    public class RetailContext : DbContext
    {
        public RetailContext()
            : base("SqliteTest")
        {
        }
        public DbSet<Person> Persons { set; get; }
        public DbSet<b1> B1 { set; get; }

    }
}
