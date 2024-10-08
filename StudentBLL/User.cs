using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL
{
    public class User
    {

        public static List<Student.Model.User> List()
        {
            return Student.DAL.User.List();
        }
        public static bool Login(string username, string password)
        {
            return Student.DAL.User.Login(username, password);
        }

        public static bool add(Student.Model.User user)
        {
            return Student.DAL.User.add(user);
        }

        public static bool update(Student.Model.User user)
        {
            return Student.DAL.User.update(user);
        }

        public static bool Search(string username)
        {
            return Student.DAL.User.Search(username);
        }

        public static Model.User Getuser(string username)
        {
            return Student.DAL.User.Getuser(username);
        }

        public static Model.User Getuser(int id)
        {
            return Student.DAL.User.Getuser(id);
        }

        public static bool del(int id)
        {
            return Student.DAL.User.del(id);
        }
    }
}
