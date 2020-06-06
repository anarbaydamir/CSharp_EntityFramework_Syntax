using System;
using System.Collections.Generic;

namespace TestEntityFramework
{
    public interface EntityFrameworkInter
    {
        public List<Users> getAll();

        public Users getById(int id);

        public void add(Users user);

        public void update(Users user);

        public void delete(Users user);
    }
}
