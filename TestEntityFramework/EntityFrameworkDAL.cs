using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace TestEntityFramework
{
    public class EntityFrameworkDAL : EntityFrameworkInter
    {
        public List<Users> getAll()
        {
            using(TestDbContext testDbContext = new TestDbContext())
            {
                List<Users> users = testDbContext.usersTb.ToList();

                return users;
            }
        }

        public Users getById(int id)
        {
            using(TestDbContext testDbContext = new TestDbContext())
            {
               // Users users = new Users();
                Users users = testDbContext.usersTb.First(usersDb => usersDb.id == id); //if user doesnt exist throws an exception
                Users users2 = testDbContext.usersTb.FirstOrDefault(usersDb => usersDb.id == id); //returns null if users doesnt exist
                List<Users> users3 = testDbContext.usersTb.Where(usersDb => usersDb.id == id).ToList();
                return users;
            }
        }

        public void add(Users user)
        {
            using (TestDbContext testDbContext = new TestDbContext())
            {
                testDbContext.usersTb.Add(user);
                testDbContext.SaveChanges();
            }
        }

        public void update(Users user)
        {
            using (TestDbContext testDbContext = new TestDbContext())
            {
                var entity = testDbContext.Entry(user);
                entity.State = EntityState.Modified;
                testDbContext.SaveChanges();
            }
        }

        public void delete(Users user)
        {
            using(TestDbContext testDbContext = new TestDbContext())
            {
                var entity = testDbContext.Entry(user);
                entity.State = EntityState.Deleted;
                testDbContext.SaveChanges();

                //second type
                testDbContext.usersTb.Remove(user);
            }
        }

        public List<Users> GetUsersByName(string name)
        {
            using(TestDbContext testDbContext = new TestDbContext())
            {
                List<Users> users = testDbContext.usersTb.Where(u => u.name.Contains(name)).ToList();

                return users;
            }
        }

    }
}
