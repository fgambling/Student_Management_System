using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL
{
    public class Result
    {

        public static bool add(Student.Model.Results results)
        {
            return Student.DAL.Result.add(results);
        }

        public static List<Student.Model.Results> List()
        {
            return Student.DAL.Result.List();
        }

        public static List<Student.Model.Results> List(string str)
        {
            return Student.DAL.Result.List(str);
        }

        public static List<Student.Model.Results> List(int userId, int courseId)
        {
            return Student.DAL.Result.List(userId, courseId);
        }

        public static List<Student.Model.Results> List(int userId)
        {
            return Student.DAL.Result.List(userId);
        }

        public static Model.Results Getresult(int id)
        {
            return Student.DAL.Result.Getresult(id);
        }

        public static bool update(int num, int id)
        {
            return Student.DAL.Result.update(num, id);
        }

        public static bool del(int id)
        {
            return Student.DAL.Result.del(id);
        }

    }
}
