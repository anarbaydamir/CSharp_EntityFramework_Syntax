using System;
using System.Data.Entity;

namespace TestEntityFramework
{
    public class TestDbContext:DbContext
    {
       //map db table with c# class
      public DbSet<Users> usersTb { get; set; }
    }
}
